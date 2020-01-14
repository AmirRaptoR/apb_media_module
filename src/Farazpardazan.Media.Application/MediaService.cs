using System.IO;
using System.Threading.Tasks;
using Farazpardazan.Media.Localization;
using Farazpardazan.Media.Samples;
using Volo.Abp.Application.Services;

namespace Farazpardazan.Media
{
    public class MediaService : ApplicationService, IMediaService
    {
        private readonly IFileSystem _fileSystem;
        private readonly MediaOptions _options;
        private readonly IMediaRepository _repository;

        public MediaService(IFileSystem fileSystem, MediaOptions options, IMediaRepository repository)
        {
            LocalizationResource = typeof(MediaResource);
            ObjectMapperContext = typeof(MediaApplicationModule);
            _fileSystem = fileSystem;
            _options = options;
            _repository = repository;
        }

        public async Task<MediaDto> Create(Stream input, string fileName, string contentType)
        {
            using var memoryStream = new MemoryStream();
            await input.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            var hash = HashHelper.CreateSha256(memoryStream);
            memoryStream.Position = 0;
            var actualFileName = StringHelper.CreateRandom(32);
            var path = Path.Combine(_options.BasePath, actualFileName);
            await _fileSystem.WriteFile(path, memoryStream, true);
            memoryStream.Position = 0;
            var media = new MediaEntity(fileName, actualFileName, hash, actualFileName, contentType, memoryStream.Length);
            return ObjectMapper.Map<MediaEntity, MediaDto>(await _repository.InsertAsync(media));
        }

        public async Task<MediaDto> GetById(long id)
        {
            return ObjectMapper.Map<MediaEntity, MediaDto>(await _repository.GetAsync(id));
        }

        public async Task<MediaDto> GetByUniqueId(string uniqueId)
        {
            return ObjectMapper.Map<MediaEntity, MediaDto>(await _repository.GetByUniqueId(uniqueId));
        }

        public Task<Stream> GetStream(MediaDto media)
        {
            var path = Path.Combine(_options.BasePath, media.Address);
            return _fileSystem.ReadFile(path);
        }
    }
}
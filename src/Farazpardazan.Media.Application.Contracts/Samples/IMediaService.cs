using System.IO;
using System.Threading.Tasks;

namespace Farazpardazan.Media.Samples
{
    public interface IMediaService
    {
        Task<MediaDto> Create(Stream input, string fileName, string contentType);
        Task<MediaDto> GetById(long id);
        Task<MediaDto> GetByUniqueId(string uniqueId);
        Task<Stream> GetStream(MediaDto media);
    }
}
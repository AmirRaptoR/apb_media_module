using System.Threading.Tasks;
using System.Xml;
using Farazpardazan.Media.Localization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Farazpardazan.Media.Samples
{
    public class UploadResponse
    {
        public string DownloadUrl { get; set; }
        public string PreviewUrl { get; set; }
        public string Hash { get; set; }
        public long Size { get; set; }
    }

    [RemoteService]
    [Route("api/media")]
    public class SampleController : AbpController
    {
        private readonly IMediaService _mediaService;
        private readonly IUrlHelper _urlHelper;

        public SampleController(IMediaService mediaService, IUrlHelper urlHelper)
        {
            LocalizationResource = typeof(MediaResource);
            _mediaService = mediaService;
            _urlHelper = urlHelper;
        }

        [HttpPost("")]
        public async Task<IActionResult> Upload([FromBody] IFormFile file)
        {
            var media = await _mediaService.Create(file.OpenReadStream(), file.FileName, file.ContentType);
            return Ok(new UploadResponse
            {
                DownloadUrl = _urlHelper.Action("Download", new {uniqueId = media.UniqueId}),
                PreviewUrl = _urlHelper.Action("Download", new {uniqueId = media.UniqueId}),
                Hash = media.Hash,
                Size = media.Size
            });
        }

        [HttpGet("{uniqueId}/preview")]
        public async Task<IActionResult> Preview([FromRoute] string uniqueId)
        {
            var media = await _mediaService.GetByUniqueId(uniqueId);
            var stream = await _mediaService.GetStream(media);

            return File(stream, media.ContentType);
        }

        [HttpGet("{uniqueId}")]
        public async Task<IActionResult> Download([FromRoute] string uniqueId)
        {
            var media = await _mediaService.GetByUniqueId(uniqueId);
            var stream = await _mediaService.GetStream(media);

            return File(stream, media.ContentType, media.FileName, true);
        }
    }
}
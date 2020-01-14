using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Farazpardazan.Media.Samples
{
    public class SampleAppService_Tests : MediaApplicationTestBase
    {
        private readonly IMediaService _mediaService;

        public SampleAppService_Tests()
        {
            _mediaService = GetRequiredService<IMediaService>();
        }

     
    }
}

using Volo.Abp.Modularity;

namespace Farazpardazan.Media
{
    [DependsOn(
        typeof(MediaApplicationModule),
        typeof(MediaDomainTestModule)
        )]
    public class MediaApplicationTestModule : AbpModule
    {

    }
}

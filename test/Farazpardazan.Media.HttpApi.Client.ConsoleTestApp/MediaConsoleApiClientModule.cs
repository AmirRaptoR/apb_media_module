using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Farazpardazan.Media
{
    [DependsOn(
        typeof(MediaHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class MediaConsoleApiClientModule : AbpModule
    {
        
    }
}

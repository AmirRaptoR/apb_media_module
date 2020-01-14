using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Farazpardazan.Media
{
    [DependsOn(
        typeof(MediaApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class MediaHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Media";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(MediaApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}

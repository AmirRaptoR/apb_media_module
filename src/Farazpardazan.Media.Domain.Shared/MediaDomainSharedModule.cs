using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Farazpardazan.Media.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Farazpardazan.Media
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class MediaDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MediaDomainSharedModule>("Farazpardazan.Media");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<MediaResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Media");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Media", typeof(MediaResource));
            });
        }
    }
}

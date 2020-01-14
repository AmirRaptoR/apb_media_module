using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Farazpardazan.Media.MongoDB
{
    public static class MediaMongoDbContextExtensions
    {
        public static void ConfigureMedia(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MediaMongoModelBuilderConfigurationOptions(
                MediaDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}
using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Farazpardazan.Media.MongoDB
{
    public class MediaMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public MediaMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
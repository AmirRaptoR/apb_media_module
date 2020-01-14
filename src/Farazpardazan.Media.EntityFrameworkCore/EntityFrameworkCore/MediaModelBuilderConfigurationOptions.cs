using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Farazpardazan.Media.EntityFrameworkCore
{
    public class MediaModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public MediaModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
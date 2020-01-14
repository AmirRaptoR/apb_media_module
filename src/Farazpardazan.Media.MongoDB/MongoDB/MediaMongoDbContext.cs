using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Farazpardazan.Media.MongoDB
{
    [ConnectionStringName(MediaDbProperties.ConnectionStringName)]
    public class MediaMongoDbContext : AbpMongoDbContext, IMediaMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureMedia();
        }
    }
}
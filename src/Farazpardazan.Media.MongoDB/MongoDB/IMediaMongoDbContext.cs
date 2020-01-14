using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Farazpardazan.Media.MongoDB
{
    [ConnectionStringName(MediaDbProperties.ConnectionStringName)]
    public interface IMediaMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}

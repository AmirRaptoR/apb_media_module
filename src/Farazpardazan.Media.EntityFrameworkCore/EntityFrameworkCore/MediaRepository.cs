using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Farazpardazan.Media.EntityFrameworkCore
{
    public class MediaRepository : EfCoreRepository<MediaDbContext, MediaEntity, long>, IMediaRepository
    {
        public MediaRepository(IDbContextProvider<MediaDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public Task<MediaEntity> GetByUniqueId(string uniqueId)
        {
            return DbContext.Medias.Where(x => x.UniqueId == uniqueId).FirstOrDefaultAsync();
        }
    }
}
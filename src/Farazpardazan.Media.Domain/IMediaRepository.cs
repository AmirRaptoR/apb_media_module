using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Farazpardazan.Media
{
    public interface IMediaRepository : IRepository<MediaEntity, long>
    {
        Task<MediaEntity> GetByUniqueId(string uniqueId);
    }
}
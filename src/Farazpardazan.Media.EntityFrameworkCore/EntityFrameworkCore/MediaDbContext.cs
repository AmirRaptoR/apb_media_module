using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Farazpardazan.Media.EntityFrameworkCore
{
    [ConnectionStringName(MediaDbProperties.ConnectionStringName)]
    public class MediaDbContext : AbpDbContext<MediaDbContext>, IMediaDbContext
    {
        public DbSet<MediaEntity> Medias { get; set; }

        public MediaDbContext(DbContextOptions<MediaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureMedia();
        }
    }
}
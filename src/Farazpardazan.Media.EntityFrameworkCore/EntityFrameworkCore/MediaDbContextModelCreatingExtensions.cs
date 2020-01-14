using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Farazpardazan.Media.EntityFrameworkCore
{
    public static class MediaDbContextModelCreatingExtensions
    {
        public static void ConfigureMedia(
            this ModelBuilder builder,
            Action<MediaModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MediaModelBuilderConfigurationOptions(
                MediaDbProperties.DbTablePrefix,
                MediaDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<MediaEntity>(b =>
            {
                b.ToTable("medias");
                b.ConfigureCreationAudited();
                b.Property(x => x.Address).IsRequired();
                b.Property(x => x.Hash).IsRequired().HasMaxLength(512);
                b.Property(x => x.Size).IsRequired();
                b.Property(x => x.ContentType).IsRequired().HasDefaultValue("application/octet-stream");
                b.Property(x => x.FileName).IsRequired();
                b.Property(x => x.UniqueId).IsRequired();

                b.HasIndex(x => new
                {
                    x.UniqueId
                }).IsUnique();
            });
        }
    }
}
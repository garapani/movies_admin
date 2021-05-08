using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class DirectorEntityTypeConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> directorEntityTypeBuilder)
        {
            directorEntityTypeBuilder.Property(e => e.DirectorId).HasColumnName("DirectorID");

            directorEntityTypeBuilder.OwnsOne(a => a.Image, i =>
            {
                i.WithOwner();
                i.Property(i => i.ImageUrl).HasColumnName("ImageUrl").IsRequired();
            }).Navigation(p => p.Image).IsRequired();

        }
    }
}

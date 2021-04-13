using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class CrewEntityTypeConfiguration : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> crewEntityTypeBuilder)
        {
            crewEntityTypeBuilder.Property(e => e.CrewId).HasColumnName("CrewID");

            crewEntityTypeBuilder.OwnsOne(a => a.Image, i =>
            {
                i.WithOwner();
                i.Property(i => i.ImageUrl).HasColumnName("ImageUrl").IsRequired();
            }).Navigation(p => p.Image).IsRequired();

            crewEntityTypeBuilder.OwnsOne(a => a.Department, g =>
            {
                g.WithOwner();
                g.Property(g => g.Name).HasColumnName("Department").IsRequired();
            }).Navigation(p => p.Department).IsRequired();
        }
    }
}
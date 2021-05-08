using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class ActorEntityTypeConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> actorEntityTypeBuilder)
        {
            actorEntityTypeBuilder.Property(e => e.ActorId).HasColumnName("ActorID");

            actorEntityTypeBuilder.OwnsOne(a => a.Image, i =>
            {
                i.WithOwner();
                i.Property(i => i.ImageUrl).HasColumnName("ImageUrl").IsRequired();
            }).Navigation(p => p.Image).IsRequired();

            actorEntityTypeBuilder.OwnsOne(a => a.Gender, g =>
            {
                g.WithOwner();
                g.Property(g => g.Name).HasColumnName("Gender");
            }).Navigation(p => p.Gender);
        }
    }
}

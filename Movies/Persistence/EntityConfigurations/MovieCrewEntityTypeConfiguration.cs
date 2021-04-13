using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class MovieCrewEntityTypeConfiguration : IEntityTypeConfiguration<MovieCrew>
    {
        public void Configure(EntityTypeBuilder<MovieCrew> movieCrewEntityTypeBuilder)
        {
            movieCrewEntityTypeBuilder.HasKey(mc => new { mc.MovieId, mc.CrewId })
               .IsClustered(false);

            movieCrewEntityTypeBuilder.HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCrew)
                .HasForeignKey(mc => mc.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieCrew_Movies");

            movieCrewEntityTypeBuilder.HasOne(mc => mc.Crew)
                .WithMany(c => c.MovieCrew)
                .HasForeignKey(mc => mc.CrewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieCrew_Crew");
        }
    }
}

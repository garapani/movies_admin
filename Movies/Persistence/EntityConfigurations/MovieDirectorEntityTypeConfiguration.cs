using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class MovieDirectorEntityTypeConfiguration : IEntityTypeConfiguration<MovieDirector>
    {
        public void Configure(EntityTypeBuilder<MovieDirector> movieDirectorEntityTypeBuilder)
        {
            movieDirectorEntityTypeBuilder.HasKey(md => new { md.MovieId, md.DirectorId })
               .IsClustered(false);

            movieDirectorEntityTypeBuilder.HasOne(md => md.Movie)
                .WithMany(m => m.MovieDirectors)
                .HasForeignKey(md => md.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieDirector_Movies");

            movieDirectorEntityTypeBuilder.HasOne(md => md.Director)
                .WithMany(d => d.MovieDirectors)
                .HasForeignKey(md => md.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieDirector_Directors");
        }
    }
}

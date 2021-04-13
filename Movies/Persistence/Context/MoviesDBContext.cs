using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;

namespace Persistence.Context
{
    public class MoviesDBContext : DbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options)
            : base(options)
        {
        }

        public MoviesDBContext() : base()
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CrewEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ActorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new MovieCrewEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieActorEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MovieDirectorEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
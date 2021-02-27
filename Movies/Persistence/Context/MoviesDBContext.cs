using Microsoft.EntityFrameworkCore;
using Domain.Entity;

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
        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasOne<Image>(a=> a.Image).WithOne()
            modelBuilder.Entity<MovieCast>().HasKey(mg => new { mg.MovieId, mg.ActorId });
            modelBuilder.Entity<MovieCrew>().HasKey(mg => new { mg.MovieId, mg.CrewId });
            modelBuilder.Entity<MovieGenre>().HasKey(mg => new { mg.MovieId, mg.GenreId });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
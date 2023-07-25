using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using movies_api.Entities;

namespace movies_api
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        //fluent Api ovveriding for composite primary key:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>()
                .HasKey(x => new { x.ActorId, x.MovieId });

            modelBuilder.Entity<MoviesGenres>()
                .HasKey(x => new { x.GenreId, x.MovieId });

            modelBuilder.Entity<MovieTheatersMovies>()
                .HasKey(x => new { x.MovieTheaterId, x.MovieId });

            base.OnModelCreating(modelBuilder);  //trebuie neaparat asta pt identity
        }



        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieTheater> MovieTheaters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }
        public DbSet<MoviesGenres> MoviesGenres { get; set; }
        public DbSet<MovieTheatersMovies> MovieTheatersMovies { get; set; }
        public DbSet<Rating> Ratings { get; set; }

    }
}

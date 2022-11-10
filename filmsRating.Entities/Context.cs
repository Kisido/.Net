using Microsoft.EntityFrameworkCore;
using filmsRating.Entities.Models;

namespace filmsRating.Entities;
public class Context : DbContext
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Country> Countrys { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRating> UserRatings { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Actors

        builder.Entity<Actor>().ToTable("actors");
        builder.Entity<Actor>().HasKey(x => x.Id);

        #endregion

        #region Countrys

        builder.Entity<Country>().ToTable("countrys");
        builder.Entity<Country>().HasKey(x => x.Id);

        #endregion

        #region Genres

        builder.Entity<Genre>().ToTable("genres");
        builder.Entity<Genre>().HasKey(x => x.Id);

        #endregion

        #region Movies

        builder.Entity<Movie>().ToTable("movies");
        builder.Entity<Movie>().HasKey(x => x.Id);
        builder.Entity<Movie>().HasOne(x => x.Country)
                               .WithMany(x => x.Movies)
                               .HasForeignKey(x => x.CountryID)
                               .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region MovieActors

        builder.Entity<MovieActor>().ToTable("movieActors");
        builder.Entity<MovieActor>().HasKey(x => x.Id);
        builder.Entity<MovieActor>().HasOne(x => x.Movie)
                                    .WithMany(x => x.MovieActors)
                                    .HasForeignKey(x => x.MovieID)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<MovieActor>().HasOne(x => x.Actor)
                                    .WithMany(x => x.MovieActors)
                                    .HasForeignKey(x => x.ActorID)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region MovieGenres

        builder.Entity<MovieGenre>().ToTable("movieGenres");
        builder.Entity<MovieGenre>().HasKey(x => x.Id);
        builder.Entity<MovieGenre>().HasOne(x => x.Movie)
                                    .WithMany(x => x.MovieGenres)
                                    .HasForeignKey(x => x.MovieID)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<MovieGenre>().HasOne(x => x.Genre)
                                    .WithMany(x => x.MovieGenres)
                                    .HasForeignKey(x => x.GenreID)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<User>().HasKey(x => x.Id);

        #endregion

        #region UserRatings

        builder.Entity<UserRating>().ToTable("userRatings");
        builder.Entity<UserRating>().HasKey(x => x.Id);
        builder.Entity<UserRating>().HasOne(x => x.User)
                                    .WithMany(x => x.UserRatings)
                                    .HasForeignKey(x => x.UserID)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<UserRating>().HasOne(x => x.Movie)
                                    .WithMany(x => x.UserRatings)
                                    .HasForeignKey(x => x.MovieID)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}
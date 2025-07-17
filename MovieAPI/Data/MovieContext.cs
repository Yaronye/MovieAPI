using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
public class MovieContext : DbContext
{
    public MovieContext (DbContextOptions<MovieContext> options)
        : base(options)
    {
    }
    public MovieContext()
    {
    }

    public DbSet<Movie> Movies { get; set; } = default!;
    public DbSet<MovieDetails> MovieDetails { get; set; } = default!;
    public DbSet<Actor> Actors { get; set; } = default!;
    public DbSet<Review> Reviews { get; set; } = default!;
    public DbSet<Genre> Genres { get; set; } = default!;

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);

    //    modelBuilder.Entity<Movie>()
    //        .HasOne(m => m.MovieDetails)
    //        .WithOne(d => d.Movie)
    //        .HasForeignKey<MovieDetails>(d => d.MovieId);

    //    modelBuilder.Entity<MovieDetails>()
    //        .HasIndex(d => d.MovieId)
    //        .IsUnique(); //ensures one-to-one
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = MovieDatabase");
    }
}

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = MovieDatabase");
    }
}

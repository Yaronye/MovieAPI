using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MovieAPI.Models;
using System;
using MovieAPI.Extensions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace MovieAPI.Data
{
    public class SeedData
    {
        private static Faker faker = new Faker("en");
        internal static async Task InitAsync(MovieContext context)
        {
            if (await context.Movies.AnyAsync()) return;
            var movies = GenerateMovies(20);
            var actors = GenerateActors(100);
            var details = GenerateMovieDetails(20);
        }

        private static List<Actor> GenerateActors(int numberOfActors)
        {
            var actors = new List<Actor>();
            for(int i = 0; i < numberOfActors; i++)
            {
                var name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Name.FullName());
                var birthYear = DateTime.Now.Year;
                var actor = new Actor { Name = name, BirthYear = birthYear };
                actors.Add(actor);
            }
            return actors;

        }
        private static List<Movie> GenerateMovies(int numberOfMovies)
        {
            Random random = new Random();
            var movies = new List<Movie>();
            for(int i = 0; i < numberOfMovies; i++)
            {
                var title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Company.Bs());
                var year = DateTime.Now.Year;
                var duration = random.Next(20, 201);
                var movie = new Movie { Title = title, Year = year, Duration = duration };
                movies.Add(movie);
            }
            return movies;
        }

        private static List<MovieDetails> GenerateMovieDetails(int numberOfDetails)
        {
            Random random = new Random();
            var details = new List<MovieDetails>();
            for (int i =0; i < numberOfDetails; i++)
            {
                var synopsis = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Company.Bs());
                var randInt = random.Next(0, Enum.GetNames(typeof(Languages)).Length);
                var language = (Languages)randInt; 
                var budget = random.Next(60000, 2000001);
                var movie = GenerateMovies(1)[0];
                var detail = new MovieDetails { Budget = budget, Movie = movie, Language = language, Synoposis = synopsis };
                details.Add(detail);
            }
            return details;
        }
    }
}

using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MovieAPI.Models;
using System;
using MovieAPI.Extensions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Bogus.DataSets;

namespace MovieAPI.Data
{
    public class SeedData
    {
        private static Faker faker = new Faker("en");
        internal static async Task InitAsync(MovieContext context)
        {
            if (await context.Movies.AnyAsync()) return;
            var movies = GenerateMovies(20);
        }
        private static List<Movie> GenerateMovies(int numberOfMovies)
        {
            Random random = new Random();
            var movies = new List<Movie>();
            var genres = GenerateGenres();
            var actorList = GenerateActors(random.Next(1, 40));
            var reviewList = GenerateReviews(random.Next(3, 7));
            MovieDetails details = GenerateMovieDetails();

            for (int i = 0; i < numberOfMovies; i++)
            {
                var title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Company.Bs());
                var year = DateTime.Now.Year;
                var duration = random.Next(20, 201);
                var movie = new Movie { Title = title, Year = year, Duration = duration, MovieDetails =  };

                movies.Add(movie);
            }
            return movies;
        }

        private static List<Actor> GenerateActors(int numberOfActors)
        {
            var actors = new List<Actor>();
            for (int i = 0; i < numberOfActors; i++)
            {
                var name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Name.FullName());
                var birthYear = DateTime.Now.Year;
                var actor = new Actor { Name = name, BirthYear = birthYear };
                actors.Add(actor);
            }
            return actors;

        }

        private static MovieDetails GenerateMovieDetails()
        {
            Random random = new Random();
            var synopsis = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Company.Bs());
            var randInt = random.Next(0, Enum.GetNames(typeof(LanguagesEnum)).Length);
            var language = (LanguagesEnum)randInt;
            var budget = random.Next(60000, 2000001);
            var details = new MovieDetails { Budget = budget, Language = language, Synoposis = synopsis };            
            return details;
        }

        private static List<Genre> GenerateGenres()
        { 
            List<String> allGenres = ["Horror", "Action", "Fantasy","Adventure", "Musical", "Thriller", "Animated", "Family", "Comedy", "Romance"];
            List<Genre> genres = new List<Genre>();
            Random random = new Random();
            int nrGenres = random.Next(0, 4);
            for (int i = 0; i< nrGenres; i++)
            {
                int randInt = random.Next(0, allGenres.Count);
                genres.Add(new Genre { Name = allGenres[randInt]});
                allGenres.RemoveAt(randInt);
            }
            return genres;
        }
        
        private static List<Review> GenerateReviews(int nrOfReviews)
        {
            Random random = new Random();
            var reviews = new List<Review>();
            for (int i = 0; nrOfReviews > 0; i++) 
            {
                var reviewerName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Name.FullName());
                var comment = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Lorem.ToString());
                var rating = random.Next(0, 11);
                var review = new Review { ReviewerName = reviewerName, Comment = comment, Rating = rating};
                reviews.Add(review);
            }
            return reviews;
        }
    }
}

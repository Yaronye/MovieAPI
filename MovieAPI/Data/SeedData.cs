﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MovieAPI.Models;
using System;
using MovieAPI.Extensions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using static Bogus.DataSets.Name;
using MovieAPI.Migrations;

namespace MovieAPI.Data
{
    public class SeedData
    {
        private static Faker faker = new Faker("en");
        internal static async Task InitAsync(MovieContext context)
        {
            if (await context.Movies.AnyAsync()) return;
            var genres = GenerateGenres();
            await context.AddRangeAsync(genres);

            if (await context.Movies.AnyAsync()) return;
            var actors = GenerateActors(80);
            await context.AddRangeAsync(actors);

            var movies = GenerateMovies(20, genres, actors);
            await context.AddRangeAsync(movies);
            await context.SaveChangesAsync();
        }
        private static List<Movie> GenerateMovies(int numberOfMovies, List<Genre> genresList, List<Actor> actorList)
        {
            var movies = new List<Movie>();

            for (int i = 0; i < numberOfMovies; i++)
            {

                var title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Lorem.Word());
                var year = DateTime.Now.Year;
                MovieDetails details = GenerateMovieDetails();
                var duration = faker.Random.Int(20, 201);
                var genres = genresList[faker.Random.Int(0, genresList.Count - 1)];
                var reviewList = GenerateReviews(faker.Random.Int(3, 7));
                var actors = new List<Actor>();
                for(int j =0;  j < faker.Random.Int(2, 50); j++)
                {
                    actors.Add(actorList[j]);
                }
                var movie = new Movie
                {
                    Title = title,
                    Year = year,
                    Duration = duration,
                    MovieDetails = details,
                    Actors = actors,
                    Reviews = reviewList,
                    Genre = genres
                };
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
            var synopsis = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Lorem.Paragraph());
            List<String> allLanguages = ["English",
        "Swedish",
        "Danish",
        "Finnish",
        "Kurdish",
        "Russian",
        "Mandarin",
        "Cantonese"];
            var randInt = faker.Random.Int(0, allLanguages.Count()-1);
            var language = allLanguages[randInt];
            var budget = faker.Random.Int(60000, 2000001);
            var details = new MovieDetails { Budget = budget, Language = language, Synopsis = synopsis };
            return details;
        }

        private static List<Genre> GenerateGenres()
        {
            List<String> allGenres = ["Horror", "Action", "Fantasy", "Adventure", "Musical", "Thriller", "Animated", "Family", "Comedy", "Romance"];
            List<Genre> genres = new List<Genre>();
            for (int i = 0; i < allGenres.Count; i++)
            {
                genres.Add(new Genre { Name = allGenres[i] });
            }
            return genres;
        }

        private static List<Review> GenerateReviews(int nrOfReviews)
        {
            var reviews = new List<Review>();
            for (int i = 0; i < nrOfReviews; i++)
            {
                var reviewerName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Name.FullName());
                var comment = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(faker.Lorem.Paragraph());
                var rating = faker.Random.Int(0, 11);
                var review = new Review { ReviewerName = reviewerName, Comment = comment, Rating = rating };
                reviews.Add(review);
            }
            return reviews;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;
using System.Globalization;
using System.Net;

namespace MovieAPI.Extensions
{
    public class Extensions
    {

        public static void SeedData()
        {
            using var db = new MovieContext();
            var movie = new Movie { Title = "Jaws", Duration = 124, Year = 1975 };
            var movie1 = new Movie { Title = "Futurama: Bender's Big Score", Duration = 89, Year = 2007 };
            db.Movies.Add(movie);
            db.Movies.Add(movie1);
            db.SaveChanges();
        }
    }
}

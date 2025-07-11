using MovieAPI.Extensions;

namespace MovieAPI.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        public string Synoposis { get; set; } = string.Empty;
        public LanguagesEnum Language { get; set; }
        public int Budget { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}

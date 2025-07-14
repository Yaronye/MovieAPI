namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Year { get; set; }
        public int Duration { get; set; }
        public int GenreId { get; set; }

        public MovieDetails MovieDetails { get; set; } = null!;
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public Genre Genre { get; set; } = null!;
    }

    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Year { get; set; }
        public int Duration { get; set; }
        public string GenreName { get; set; } = null!;

        public string Synoposis { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public int Budget { get; set; }
    }
}

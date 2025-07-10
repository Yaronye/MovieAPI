namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null;
        public int Year { get; set; }
        public int Duration { get; set; }

        public MovieDetails MovieDetails { get; set; } = null;
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}

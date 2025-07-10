namespace MovieAPI.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int BirthYear { get; set; }

        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}

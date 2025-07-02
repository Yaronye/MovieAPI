namespace MovieAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        string ReviewerName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}

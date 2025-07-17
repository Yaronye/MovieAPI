using System.ComponentModel.DataAnnotations;
using MovieApi.Models;

namespace MovieApi.Models.DTOs;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Year { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; } = null!;

    public string Synopsis { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public int Budget { get; set; }
}
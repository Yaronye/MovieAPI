using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models.DTOs;

public class MovieCreateDto
{
    [Required]
    [StringLength(150)]
    public string Title { get; set; } = null!;

    [Range(1700, 2225)]
    public int Year { get; set; }

    [Range(1, 1200)]
    public int Duration { get; set; }
    [Required]
    public int GenreId { get; set; }
}
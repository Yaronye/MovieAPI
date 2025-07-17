using System.ComponentModel.DataAnnotations;
using MovieApi;

namespace MovieApi.Models.DTOs;

public class MovieUpdateDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    [StringLength(150)]
    public string Title { get; set; } = null!;

    [Range(1700, 2225)]
    public int Year { get; set; }

    [Range(1, 1200)]
    public int Duration { get; set; }
}
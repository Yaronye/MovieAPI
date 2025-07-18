using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models.DTOs;

public class MovieDetailsDto
{
    [Required]
    public int Id { get; set; }
    public int Budget { get; set; }

    [StringLength(50)]
    public string Language { get; set; } = string.Empty;

    [StringLength(1000)]
    public string Synopsis { get; set; } = string.Empty;
    [Required]
    public int MovieId { get; set; }
}
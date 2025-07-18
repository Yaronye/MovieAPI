using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models.DTOs;

public class ActorCreateDto
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [StringLength(150)]
    public string Name { get; set; } = null!;

    [Range(1900, 2025)]
    public int BirthYear { get; set; }
}
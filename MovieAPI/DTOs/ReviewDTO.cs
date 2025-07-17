using MovieApi.Models.DTOs;

namespace MovieApi.Models.DTOs;
public record ReviewDto(string ReviewerName, string? Comment, int Rating);
public record ReviewMovieDto(MovieDto Movie, List<ReviewDto> Reviews);
namespace Service.DTO;

public class CreateMovieDto
{
    public string Title { get; set; }
    public int Year { get; set; }
    public int DurationMinutes { get; set; }
    public Guid GenreId { get; set; }
}
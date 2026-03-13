namespace Domain.Models;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int DurationMinutes { get; set; }
    public bool IsWatched { get; set; }
    public int? Rating { get; set; }
    public Genre Genre { get; set; }
    public Guid GenreId { get; set; }
}
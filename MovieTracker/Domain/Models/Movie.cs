namespace Domain.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int DurationMinutes { get; set; }
    public bool IsWatched { get; set; }
    public int? Rating { get; set; }
    public Genre Genre { get; set; }
    public int GenreId { get; set; }
}
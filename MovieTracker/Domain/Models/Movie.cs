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
    public List<MovieActor> MovieActors { get; set; }

    public Movie(string title, int year, int durationMinutes, Genre genre, Guid genreId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Year = year;
        DurationMinutes = durationMinutes;
        IsWatched = false;
        Genre = genre;
        GenreId = genreId;
        MovieActors = new List<MovieActor>();
    }
    
    private Movie(string title, int year, int durationMinutes, Guid genreId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Year = year;
        DurationMinutes = durationMinutes;
        IsWatched = false;
        GenreId = genreId;
        MovieActors = new List<MovieActor>();
    }
}
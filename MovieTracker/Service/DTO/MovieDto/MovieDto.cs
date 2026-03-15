namespace Service.DTO;

public class MovieDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int DurationMinutes { get; set; }
    public bool IsWatched { get; set; }
    public int? Rating { get; set; }
    public string GenreName { get; set; }
    public List<string> ActorsName { get; set; }

    public MovieDto(Guid id, string title, int year, int durationMinutes, bool isWatched, int? rating, string genreName,
        List<string> actorsName)
    {
        Id = id;
        Title = title;
        Year = year;
        DurationMinutes = durationMinutes;
        IsWatched = isWatched;
        Rating = rating;
        GenreName = genreName;
        ActorsName = actorsName;
    }
}
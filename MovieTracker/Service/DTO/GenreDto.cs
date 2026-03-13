namespace Service.DTO;

public class GenreDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int MoviesCount { get; set; }

    public GenreDto(Guid id, string name, int moviesCount)
    {
        Id = id;
        Name = name;
        MoviesCount = moviesCount;
    }
    
    public GenreDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
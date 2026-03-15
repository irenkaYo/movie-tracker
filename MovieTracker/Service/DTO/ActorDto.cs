namespace Service.DTO;

public class ActorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int BirthYear { get; set; }
    public int MoviesCount { get; set; }

    public ActorDto(Guid id, string name, int birthYear, int moviesCount)
    {
        Id  = id;
        Name = name;
        BirthYear = birthYear;
        MoviesCount = moviesCount;
    }
    
    public ActorDto(Guid id, string name, int birthYear)
    {
        Id  = id;
        Name = name;
        BirthYear = birthYear;
    }
}
namespace Domain.Models;

public class Genre
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public Genre(string name)
    {
        Id  = Guid.NewGuid();
        Name = name;
    }
}
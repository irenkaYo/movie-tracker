namespace Domain.Models;

public class Actor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int BirthYear { get; set; }

    public Actor(string name, int birthYear)
    {
        Id = Guid.NewGuid();
        Name = name;
        BirthYear = birthYear;
    }
}
namespace Domain.Models;

public class MovieActor
{
    public Guid MovieId { get; set; }
    public Guid ActorId { get; set; }
    
    public MovieActor(Guid movieId, Guid actorId)
    {
        MovieId = movieId;
        ActorId = actorId;
    }
}
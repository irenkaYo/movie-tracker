using Domain.Models;
using Infrastructure.EFRepository;
using Infrastructure.InterfacesRepositories;

namespace Infrastructure.Repositories;

public class ActorRepository : IActorRepository
{
    MovieTrackerContext db =  new MovieTrackerContext();
    public List<Actor> GetAllActors()
    {
        List<Actor> Actors = db.Actors.ToList();
        return Actors;
    }

    public Actor? GetActorById(int id)
    {
        Actor? actor = db.Actors.Find(id);
        IsNull(actor);
        return actor;
    }

    public void CreateActor(Actor actor)
    {
        db.Actors.Add(actor);
        db.SaveChanges();
    }

    public void DeleteActorById(int id)
    {
        Actor? actor = db.Actors.Find(id);
        IsNull(actor);
        db.Actors.Remove(actor);
        db.SaveChanges();
    }
    
    private void IsNull(Actor? movie)
    {
        if (movie == null)
            throw new Exception("Actor not found");
    }
}
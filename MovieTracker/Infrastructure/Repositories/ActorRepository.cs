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
        db.Actors.Remove(actor);
        db.SaveChanges();
    }
}
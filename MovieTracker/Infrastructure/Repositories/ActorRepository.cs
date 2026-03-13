using Domain.Models;
using Infrastructure.EFRepository;
using Infrastructure.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ActorRepository : IActorRepository
{
    MovieTrackerContext db =  new MovieTrackerContext();
    public async Task<List<Actor>> GetAllActors()
    {
        List<Actor> Actors = await db.Actors.ToListAsync();
        return Actors;
    }

    public async Task<Actor?> GetActorById(int id)
    {
        Actor? actor = await db.Actors.FindAsync(id);
        IsNull(actor);
        return actor;
    }

    public void CreateActor(Actor actor)
    {
        db.Actors.Add(actor);
        db.SaveChanges();
    }

    public async void DeleteActorById(int id)
    {
        Actor? actor = await db.Actors.FindAsync(id);
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
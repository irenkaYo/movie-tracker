using Domain.Models;
using Infrastructure.EFRepository;
using Infrastructure.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ActorRepository : IActorRepository
{
    private readonly MovieTrackerContext db;

    public ActorRepository(MovieTrackerContext context)
    {
        db = context;
    }
    
    public async Task<List<Actor>> GetAllActors()
    {
        List<Actor> Actors = await db.Actors.ToListAsync();
        return Actors;
    }

    public async Task<Actor?> GetActorById(Guid id)
    {
        Actor? actor = await db.Actors.FindAsync(id);
        IsNull(actor);
        return actor;
    }

    public async Task CreateActor(Actor actor)
    {
        await db.Actors.AddAsync(actor);
        await db.SaveChangesAsync();
    }

    public async Task DeleteActorById(Guid id)
    {
        Actor? actor = await db.Actors.FindAsync(id);
        IsNull(actor);
        db.Actors.Remove(actor);
        await db.SaveChangesAsync();
    }
    
    private void IsNull(Actor? actor)
    {
        if (actor == null)
            throw new Exception("Actor not found");
    }
}
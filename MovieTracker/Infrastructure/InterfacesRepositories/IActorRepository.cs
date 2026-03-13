using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IActorRepository
{
    public Task<List<Actor>> GetAllActors();
    public Task<Actor?> GetActorById(Guid id);
    public Task CreateActor(Actor actor);
    public Task DeleteActorById(Guid id);
}
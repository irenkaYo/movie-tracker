using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IActorRepository
{
    public Task<List<Actor>> GetAllActors();
    public Task<Actor?> GetActorById(int id);
    public void CreateActor(Actor actor);
    public void DeleteActorById(int id);
}
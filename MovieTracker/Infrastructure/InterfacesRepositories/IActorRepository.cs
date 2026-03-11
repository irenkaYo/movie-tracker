using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IActorRepository
{
    public List<Actor> GetAllActors();
    public Actor? GetActorById(int id);
    public void CreateActor(Actor actor);
    public void DeleteActorById(int id);
}
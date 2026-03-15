using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IMovieActorRepository
{
    public Task ConnectMovieAndActor(Guid movieId, Guid actorId);
    public Task DisconnectMovieAndActor(Guid movieId, Guid actorId);
    public Task<List<Actor>> GetActorsByMovieId(Guid movieId);
}
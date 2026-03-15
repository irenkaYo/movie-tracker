using Domain.Models;
using Infrastructure.Repositories;
using Service.DTO;

namespace Service.Services;

public class MovieActorService
{
    MovieActorRepository movieActorRepository;
    public async Task<string> ConnectMovieAndActor(Guid movieId, Guid actorId)
    {
        try
        {
            await movieActorRepository.ConnectMovieAndActor(movieId, actorId);
        }
        catch (Exception e)
        {
            throw e;
        }
        return "Actor added";
    }
    
    public async Task DisconnectMovieAndActor(Guid movieId, Guid actorId)
    {
        try
        {
            await  movieActorRepository.DisconnectMovieAndActor(movieId, actorId);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    
    public async Task<List<ActorDto>> GetActorsByMovieId(Guid movieId)
    {
        List<Actor> actors;
        try
        {
            actors = await movieActorRepository.GetActorsByMovieId(movieId);
        }
        catch (Exception e)
        {
            throw e;
        }
        List<ActorDto> actorDtos = new List<ActorDto>();
        foreach (Actor actor in actors)
        {
            actorDtos.Add(new ActorDto(actor.Id, actor.Name, actor.BirthYear));
        }
        return actorDtos;
    }
}
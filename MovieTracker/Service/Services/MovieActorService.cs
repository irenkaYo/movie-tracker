using Domain.Models;
using Infrastructure.InterfacesRepositories;
using Infrastructure.Repositories;
using Service.DTO;

namespace Service.Services;

public class MovieActorService
{
    private readonly IMovieActorRepository movieActorRepository;
    public MovieActorService(IMovieActorRepository movieActorRepository)
    {
        this.movieActorRepository = movieActorRepository;
    }
    public async Task ConnectMovieAndActor(Guid movieId, Guid actorId)
    {
        try
        {
            await movieActorRepository.ConnectMovieAndActor(movieId, actorId);
        }
        catch (Exception e)
        {
            throw e;
        }
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
        List<Movie> movies;
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
            movies = await movieActorRepository.GetMoviesByActorId(actor.Id);
            actorDtos.Add(new ActorDto(actor.Id, actor.Name, actor.BirthYear, movies.Count));
        }
        return actorDtos;
    }
}
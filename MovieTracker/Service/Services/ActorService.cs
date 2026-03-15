using Domain.Models;
using Infrastructure.Repositories;
using Service.DTO;

namespace Service.Services;

public class ActorService
{
    ActorRepository actorRepository;
    MovieActorRepository movieActorRepository;
    public async Task<List<ActorDto>> GetAllActors()
    {
        List<Actor> actors = await actorRepository.GetAllActors();
        List<ActorDto> actorsDto = await ConvertFromListActorToActorDto(actors);
        return actorsDto;
    }
    
    public async Task<ActorDto> GetActorById(Guid id)
    {
        Actor? actor;
        try
        {
            actor = await actorRepository.GetActorById(id);
        }
        catch (Exception e)
        {
            throw e;
        }
        ActorDto dto = await ConvertFromActorToActorDto(actor);
        return dto;
    }
    
    public async Task CreateActor(CreateActorDto dto)
    {
        if (dto.BirthYear <= 1800 && dto.BirthYear >= 2020)
            throw new Exception("Birth year must be between 1000 and 2000");
        if (dto.Name.Length < 3 || dto.Name.Length > 30)
            throw new Exception("Name must be between 3 and 30 characters");
        Actor actor = new Actor(dto.Name, dto.BirthYear);
        await actorRepository.CreateActor(actor);
    }
    
    public async Task DeleteActorById(Guid id)
    {
        try
        {
            await actorRepository.DeleteActorById(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private async Task<List<ActorDto>> ConvertFromListActorToActorDto(List<Actor> actors)
    {
        List<ActorDto> actorsDto = new List<ActorDto>();
        foreach (Actor actor in actors)
        {
            ActorDto dto = await ConvertFromActorToActorDto(actor);
            actorsDto.Add(dto);
        }
        return actorsDto;
    }

    private async Task<ActorDto> ConvertFromActorToActorDto(Actor actor)
    {
        List<Movie> moviesByActor = await movieActorRepository.GetMoviesByActorId(actor.Id);
        ActorDto dto = new ActorDto(actor.Id, actor.Name, actor.BirthYear, moviesByActor.Count);
        return dto;
    }
}
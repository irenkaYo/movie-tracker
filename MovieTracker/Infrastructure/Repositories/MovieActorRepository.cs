using Domain.Models;
using Infrastructure.EFRepository;
using Infrastructure.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieActorRepository : IMovieActorRepository
{
    private readonly MovieTrackerContext db;

    public MovieActorRepository(MovieTrackerContext context)
    {
        db = context;
    }
    public async Task ConnectMovieAndActor(Guid movieId, Guid actorId)
    {
        bool isMovieExist = await db.Movies.AnyAsync(x => x.Id == movieId);
        bool isActorExist = await db.Actors.AnyAsync(x => x.Id == actorId);
        if (!isMovieExist || !isActorExist)
            throw new Exception("Movie or Actor doesn't exist");
        bool isActorInMovie = await db.MovieActors.AnyAsync(x => x.MovieId == movieId && x.ActorId == actorId);
        if (isActorInMovie)
            throw new Exception("Actor already in movie");
        MovieActor movieActor = new MovieActor(movieId, actorId);
        db.MovieActors.Add(movieActor);
        await db.SaveChangesAsync();
    }

    public async Task DisconnectMovieAndActor(Guid movieId, Guid actorId)
    {
        MovieActor? movieActor = await db.MovieActors.FirstOrDefaultAsync(x => x.MovieId == movieId && x.ActorId == actorId);
        if (movieActor == null)
            throw new Exception("ID not found");
        db.MovieActors.Remove(movieActor);
        await db.SaveChangesAsync();
    }

    public async Task<List<Actor>> GetActorsByMovieId(Guid movieId)
    {
        List<Actor> actors = await db.MovieActors
            .Where(ma => ma.MovieId == movieId)
            .Select(ma => ma.Actor)
            .ToListAsync();
        return actors;
    }

    public async Task<List<Movie>> GetMoviesByActorId(Guid actorId)
    {
        bool isActorExist = await db.MovieActors.AnyAsync(x => x.ActorId == actorId);
        if (!isActorExist)
            throw new Exception("Actor doesn't exist");
        List<Movie> movies = await db.MovieActors
            .Where(ma => ma.ActorId == actorId)
            .Select(ma => ma.Movie)
            .ToListAsync();
        return movies;
    }
}
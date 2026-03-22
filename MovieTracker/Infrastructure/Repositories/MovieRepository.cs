using Domain.Models;
using Infrastructure.EFRepository;
using Infrastructure.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MovieTrackerContext db;

    public MovieRepository(MovieTrackerContext context)
    {
        db = context;
    }
    
    public async Task<List<Movie>> GetAllMovies()
    {
        List<Movie> Movies = await db.Movies.Include(m => m.Genre)
                                            .Include(a => a.MovieActors)
                                            .ThenInclude(a => a.Actor)
                                            .ToListAsync();
        return Movies;
    }

    public async Task<Movie?> GetMovieById(Guid id)
    {
        Movie? movie = await db.Movies.Include(m => m.Genre)
                                      .Include(a => a.MovieActors)
                                      .ThenInclude(a => a.Actor)
                                      .FirstOrDefaultAsync(m => m.Id == id);
        IsNull(movie);
        return movie;
    }

    public async Task<List<Movie>> GetMoviesByGenreId(Guid genreId)
    {
        List<Movie> Movies = await db.Movies.Where(m => m.GenreId == genreId)
                                            .Include(m => m.Genre)
                                            .Include(a => a.MovieActors)
                                            .ThenInclude(a => a.Actor)
                                            .ToListAsync();
        return Movies;
    }

    public async Task CreateMovie(Movie movie)
    {
        await db.Movies.AddAsync(movie);
        await db.SaveChangesAsync();
    }

    public async Task UpdateMovie(Movie movie)
    {
        db.Movies.Update(movie);
        await db.SaveChangesAsync();
    }

    public async Task DeleteMovieById(Guid id)
    {
        Movie? movie = await GetMovieById(id);
        IsNull(movie);
        db.Movies.Remove(movie);
        await db.SaveChangesAsync();
    }

    private void IsNull(Movie? movie)
    {
        if (movie == null)
            throw new Exception("Movie not found");
    }
}
using Domain.Models;
using Infrastructure.EFRepository;
using Infrastructure.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    MovieTrackerContext db =  new MovieTrackerContext();
    public async Task<List<Movie>> GetAllMovies()
    {
        List<Movie> Movies = await db.Movies.Include(m => m.Genre).ToListAsync();
        return Movies;
    }

    public async Task<Movie?> GetMovieById(Guid id)
    {
        Movie? movie = await db.Movies.Include(m => m.Genre)
                                      .FirstOrDefaultAsync(m => m.Id == id);
        IsNull(movie);
        return movie;
    }

    public async Task<List<Movie>> GetMoviesByGenreId(Guid genreId)
    {
        List<Movie> Movies = await db.Movies.Where(m => m.GenreId == genreId).ToListAsync();
        return Movies;
    }

    public async Task CreateMovie(Movie movie)
    {
        await db.Movies.AddAsync(movie);
        await db.SaveChangesAsync();
    }

    public async Task MarkAsWatched(Guid id)
    {
        Movie? movie = await GetMovieById(id);
        IsNull(movie);
        movie.IsWatched = true;
        db.Movies.Update(movie);
        db.SaveChanges();
    }

    public async Task SetRating(Guid id, int rating)
    {
        Movie? movie = await GetMovieById(id);
        IsNull(movie);
        movie.Rating = rating;
        db.Movies.Update(movie);
        db.SaveChanges();
    }

    public async Task DeleteMovieById(Guid id)
    {
        Movie? movie = await GetMovieById(id);
        IsNull(movie);
        db.Movies.Remove(movie);
        db.SaveChanges();
    }

    private void IsNull(Movie? movie)
    {
        if (movie == null)
            throw new Exception("Movie not found");
    }
}
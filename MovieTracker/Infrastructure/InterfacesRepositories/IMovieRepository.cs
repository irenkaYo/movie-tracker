using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IMovieRepository
{
    public Task<List<Movie>> GetAllMovies();
    public Task<Movie?> GetMovieById(Guid id);
    public Task<List<Movie>> GetMoviesByGenreId(Guid genreId);
    public Task CreateMovie(Movie movie);
    public Task UpdateMovie(Movie movie);
    public Task DeleteMovieById(Guid id);
}
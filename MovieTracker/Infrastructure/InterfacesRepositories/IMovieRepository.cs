using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IMovieRepository
{
    public Task<List<Movie>> GetAllMovies();
    public Task<Movie?> GetMovieById(Guid id);
    public Task<List<Movie>> GetMoviesByGenreId(Guid genreId);
    public void CreateMovie(Movie movie);
    public void MarkAsWatched(Guid id);
    public void SetRating(Guid id, int rating);
    public void DeleteMovieById(Guid id);
}
using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IMovieRepository
{
    public Task<List<Movie>> GetAllMovies();
    public Task<Movie?> GetMovieById(int id);
    public Task<List<Movie>> GetMoviesByGenreId(int genreId);
    public void CreateMovie(Movie movie);
    public void MarkAsWatched(int id);
    public void SetRating(int id, int rating);
    public void DeleteMovieById(int id);
}
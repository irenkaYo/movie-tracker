using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IMovieRepository
{
    public List<Movie> GetAllMovies();
    public Movie? GetMovieById(int id);
    public List<Movie> GetMoviesByGenreId(int genreId);
    public void CreateMovie(Movie movie);
    public void MarkAsWatched(int id);
    public void SetRating(int id, int rating);
    public void DeleteMovieById(int id);
}
using Domain.Models;
using Infrastructure.EFRepository;
using Infrastructure.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    MovieTrackerContext db =  new MovieTrackerContext();
    public List<Movie> GetAllMovies()
    {
        List<Movie> Movies = db.Movies.Include(m => m.Genre).ToList();
        return Movies;
    }

    public Movie? GetMovieById(int id)
    {
        Movie? movie = db.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
        IsNull(movie);
        return movie;
    }

    public List<Movie> GetMoviesByGenreId(int genreId)
    {
        List<Movie> Movies = db.Movies.Where(m => m.GenreId == genreId).ToList();
        return Movies;
    }

    public void CreateMovie(Movie movie)
    {
        db.Movies.Add(movie);
        db.SaveChanges();
    }

    public void MarkAsWatched(int id)
    {
        Movie? movie = db.Movies.Include(m => m.Genre).FirstOrDefault(m => m.Id == id);
        IsNull(movie);
        movie.IsWatched = true;
        db.Movies.Update(movie);
        db.SaveChanges();
    }

    public void SetRating(int id, int rating)
    {
        Movie? movie = db.Movies.Find(id);
        IsNull(movie);
        movie.Rating = rating;
        db.Movies.Update(movie);
        db.SaveChanges();
    }

    public void DeleteMovieById(int id)
    {
        Movie? movie = db.Movies.Find(id);
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
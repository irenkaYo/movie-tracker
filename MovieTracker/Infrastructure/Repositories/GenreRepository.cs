using Domain.Models;
using Infrastructure.EFRepository;
using Infrastructure.InterfacesRepositories;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    MovieTrackerContext db  = new MovieTrackerContext();
    public List<Genre> GetAllGenres()
    {
        List<Genre> Genres = db.Genres.ToList();
        return Genres;
    }

    public Genre? GetGenreById(int id)
    {
        Genre? genre = db.Genres.Find(id);
        IsNull(genre);
        return genre;
    }

    public void CreateGenre(Genre genre)
    {
        db.Genres.Add(genre);
        db.SaveChanges();
    }

    public void DeleteGenreById(int id)
    {
        Genre? genre = db.Genres.Find(id);
        IsNull(genre);
        db.Genres.Remove(genre);
        db.SaveChanges();
    }
    
    private void IsNull(Genre? movie)
    {
        if (movie == null)
            throw new Exception("Genre not found");
    }
}
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
        Genre? genre = db.Genres.Find(id);//exception
        return genre;
    }

    public void CreateGenre(Genre genre)
    {
        db.Genres.Add(genre);
        db.SaveChanges();
    }

    public void DeleteGenreById(int id)
    {
        Genre? genre = db.Genres.Find(id); //exception
        db.Genres.Remove(genre);
        db.SaveChanges();
    }
}
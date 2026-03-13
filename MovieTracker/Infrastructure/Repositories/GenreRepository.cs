using Domain.Models;
using Infrastructure.EFRepository;
using Infrastructure.InterfacesRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    MovieTrackerContext db  = new MovieTrackerContext();
    public async Task<List<Genre>> GetAllGenres()
    {
        List<Genre> Genres = await db.Genres.ToListAsync();
        return Genres;
    }

    public async Task<Genre?> GetGenreById(Guid id)
    {
        Genre? genre = await db.Genres.FindAsync(id);
        IsNull(genre);
        return genre;
    }

    public async Task CreateGenre(Genre genre)
    {
        await db.Genres.AddAsync(genre);
        await db.SaveChangesAsync();
    }

    public async Task DeleteGenreById(Guid id)
    {
        Genre? genre = await db.Genres.FindAsync(id);
        IsNull(genre);
        db.Genres.Remove(genre);
        db.SaveChanges();
    }
    
    private void IsNull(Genre? genre)
    {
        if (genre == null)
            throw new Exception("Genre not found");
    }
}
using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IGenreRepository
{
    public Task<List<Genre>> GetAllGenres();
    public Task<Genre?> GetGenreById(Guid id);
    public Task CreateGenre(Genre genre);
    public Task DeleteGenreById(Guid id);
    public Task<bool> GenreExists(Guid id);
}
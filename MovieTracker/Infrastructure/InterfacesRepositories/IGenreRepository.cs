using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IGenreRepository
{
    public Task<List<Genre>> GetAllGenres();
    public Task<Genre?> GetGenreById(int id);
    public void CreateGenre(Genre genre);
    public void DeleteGenreById(int id);
}
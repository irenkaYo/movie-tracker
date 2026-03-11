using Domain.Models;

namespace Infrastructure.InterfacesRepositories;

public interface IGenreRepository
{
    public List<Genre> GetAllGenres();
    public Genre? GetGenreById(int id);
    public void CreateGenre(Genre genre);
    public void DeleteGenreById(int id);
}
using Domain.Models;
using Infrastructure.InterfacesRepositories;
using Infrastructure.Repositories;
using Service.DTO;

namespace Service.Services;

public class GenreService
{
    private readonly IGenreRepository genreRepository;
    private readonly IMovieRepository movieRepository;
    public GenreService(IGenreRepository genreRepository, IMovieRepository movieRepository)
    {
        this.genreRepository = genreRepository;
        this.movieRepository = movieRepository;
    }
    public async Task<List<GenreDto>> GetAllGenres()
    {
        List<Genre> genres = await genreRepository.GetAllGenres();
        List<GenreDto> genreDtos = await ConvertListToGenreDto(genres);
        return genreDtos;
    }
    
    public async Task<GenreDto?> GetGenreById(Guid id)
    {
        Genre? genre;
        try
        {
            genre = await genreRepository.GetGenreById(id);
        }
        catch (Exception e)
        {
            throw e;
        }
        GenreDto genreDto = new GenreDto(genre.Id, genre.Name);
        return genreDto;
    }
    
    public async Task<GenreDto> CreateGenre(CreateGenreDto genreDto)
    {
        if (genreDto.Name.Length < 3 || genreDto.Name.Length > 30)
            throw new Exception("Name must be between 3 and 30 characters");
        Genre genre = new Genre(genreDto.Name);
        await genreRepository.CreateGenre(genre);
        GenreDto dto =  new GenreDto(genre.Id, genre.Name);
        return dto;
    }
    
    public async Task DeleteGenreById(Guid id)
    {
        try
        {
            await genreRepository.DeleteGenreById(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private async Task<List<GenreDto>> ConvertListToGenreDto(List<Genre> genres)
    {
        List<GenreDto> genresDto = new List<GenreDto>();
        foreach (Genre genre in genres)
        {
            List<Movie> movies = await movieRepository.GetMoviesByGenreId(genre.Id);
            int moviesCount = movies.Count;
            GenreDto dto = new GenreDto(genre.Id, genre.Name, moviesCount);
            genresDto.Add(dto);
        }
        return genresDto;
    }
}
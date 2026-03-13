using Domain.Models;
using Infrastructure.Repositories;
using Service.DTO;

namespace Service.Services;

public class GenreService
{
    GenreRepository genreRepository;
    MovieRepository movieRepository;
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
        List<GenreDto> GenresDto = new List<GenreDto>();
        foreach (Genre genre in genres)
        {
            int moviesCount = (await movieRepository.GetMoviesByGenreId(genre.Id)).Count;
            GenreDto dto = new GenreDto(genre.Id, genre.Name, moviesCount);
            GenresDto.Add(dto);
        }
        return GenresDto;
    }
}
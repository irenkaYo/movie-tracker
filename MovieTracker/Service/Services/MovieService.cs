using Domain.Models;
using Infrastructure.InterfacesRepositories;
using Infrastructure.Repositories;
using Service.DTO;

namespace Service.Services;

public class MovieService
{
    private readonly IMovieRepository movieRepository;
    private readonly IGenreRepository genreRepository;
    private readonly IMovieActorRepository movieActorRepository;

    public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository, IMovieActorRepository movieActorRepository)
    {
        this.movieRepository = movieRepository;
        this.genreRepository = genreRepository;
        this.movieActorRepository = movieActorRepository;
    }
    
    public async Task<List<MovieDto>> GetAllMovies()
    {
        List<Movie> movies = await movieRepository.GetAllMovies();
        List<MovieDto> movieDtos = await ConvertListFromMovieToMovieDto(movies);
        return movieDtos;
    }
    
    public async Task<MovieDto> GetMovieById(Guid id)
    {
        Movie? movie;
        try
        {
            movie = await movieRepository.GetMovieById(id);
        }
        catch (Exception e)
        {
            throw e;
        }
        MovieDto dto = await ConvertMovieToMovieDto(movie);
        return dto;
    }
    
    public async Task<List<MovieDto>> GetMoviesByGenreId(Guid genreId)
    {
        List<Movie> movies = await movieRepository.GetMoviesByGenreId(genreId);
        if (movies.Count == 0)
            throw new Exception("No movies found");
        List<MovieDto> movieDtos = await ConvertListFromMovieToMovieDto(movies);
        return movieDtos;
    }
    
    public async Task<MovieDto> CreateMovie(CreateMovieDto createMovieDto)
    {
        if (createMovieDto.Title.Length < 3 || createMovieDto.Title.Length > 30)
            throw new Exception("Title must be between 3 and 30 characters");
        if (createMovieDto.Year <= 1800 || createMovieDto.Year > 2027)
            throw new Exception("Year must be between 1000 and 2000");
        if (createMovieDto.DurationMinutes < 0 || createMovieDto.DurationMinutes > 60000)
            throw new Exception("Duration must be between 0 and 60000");
        if (!await genreRepository.GenreExists(createMovieDto.GenreId))
            throw new Exception("Genre does not exist");
        Movie movie = new Movie(createMovieDto.Title, createMovieDto.Year, createMovieDto.DurationMinutes,  createMovieDto.GenreId);
        await movieRepository.CreateMovie(movie);
        MovieDto dto = await ConvertMovieToMovieDto(movie);
        return dto;
    }
    
    public async Task<MovieDto> MarkAsWatched(Guid id)
    {
        Movie? movie;
        try
        {
            await movieRepository.MarkAsWatched(id);
            movie = await movieRepository.GetMovieById(id);
        }
        catch (Exception e)
        {
            throw e;
        }
        MovieDto dto = await ConvertMovieToMovieDto(movie);
        return dto;
    }
    
    public async Task<MovieDto> SetRating(Guid id, int rating)
    {
        if  (rating < 0 || rating > 10)
            throw new Exception("Rating must be between 0 and 10");
        Movie? movie;
        try
        {
            await movieRepository.SetRating(id, rating);
            movie = await movieRepository.GetMovieById(id);
        }
        catch (Exception e)
        {
            throw e;
        }
        MovieDto dto = await ConvertMovieToMovieDto(movie);
        return dto;
    }
    
    public async Task DeleteMovieById(Guid id)
    {
        try
        {
            await movieRepository.DeleteMovieById(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    private async Task<List<MovieDto>> ConvertListFromMovieToMovieDto(List<Movie> movies)
    {
        List<MovieDto> movieDtos = new List<MovieDto>();
        foreach (Movie movie in movies)
        {
            MovieDto dto = await ConvertMovieToMovieDto(movie);
            movieDtos.Add(dto);
        }
        return movieDtos;
    }

    private async Task<MovieDto> ConvertMovieToMovieDto(Movie movie)
    {
        List<Actor> actors = await movieActorRepository.GetActorsByMovieId(movie.Id);
        List<string> actorsNames = actors.Select(x => x.Name).ToList();
        MovieDto dto = new MovieDto(movie.Id, movie.Title, movie.Year, movie.DurationMinutes, movie.IsWatched, movie.Rating, movie.Genre.Name, actorsNames);
        return dto;
    }
}
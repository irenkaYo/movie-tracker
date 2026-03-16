using Infrastructure.EFRepository;
using Microsoft.EntityFrameworkCore;
using Service.DTO;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MovieTrackerContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
GenreService genreService = new GenreService();

app.MapGet("/api/genres", async () =>
{
    var genres = await genreService.GetAllGenres();
    return Results.Ok(genres);
});

app.MapGet("/api/genres/{id:guid}", async (Guid id) =>
{
    var genre = await genreService.GetGenreById(id);
    return Results.Ok(genre);
});

app.MapPost("/api/genres", async (CreateGenreDto genreDto) =>
{
    var genre = await genreService.CreateGenre(genreDto);
    return Results.Created($"/api/genres/{genre.Id}", genre);
});

app.MapDelete("/api/genres/{id:guid}", async (Guid id) =>
{
    await genreService.DeleteGenreById(id);
    return Results.NoContent();
});


ActorService actorService = new ActorService();

app.MapGet("/api/actors", async () =>
{
    var actors = await actorService.GetAllActors();
    return Results.Ok(actors);
});

app.MapGet("/api/actors/{id:guid}", async (Guid id) =>
{
    var actor =  await actorService.GetActorById(id);
    return Results.Ok(actor);
});

app.MapPost("/api/actors", async (CreateActorDto actorDto) =>
{
    var actor = await actorService.CreateActor(actorDto);
    return Results.Ok(actor);
});

app.MapDelete("/api/actors/{id:guid}", async (Guid id) =>
{
    await actorService.DeleteActorById(id);
    return Results.NoContent();
});


MovieService movieService = new MovieService();

app.MapGet("/api/movies", async () =>
{
    var  movies = await movieService.GetAllMovies();
    return Results.Ok(movies);
});

app.MapGet("/api/movies/{id:guid}", async (Guid id) =>
{
    var movie = await movieService.GetMovieById(id);
    return Results.Ok(movie);
});

app.MapGet("/api/movies/genre/{genreId:guid}", async (Guid genreId) =>
{
    var movies = await movieService.GetMoviesByGenreId(genreId);
    return Results.Ok(movies);
});

app.MapPost("/api/movies", async (CreateMovieDto movieDto) =>
{
    var movie = await movieService.CreateMovie(movieDto);
    return Results.Created($"/api/movies/{movie.Id}", movie);
});

app.MapPatch("/api/movies/{id:guid}/watch", async (Guid id) =>
{
    var movie = await movieService.MarkAsWatched(id);
    return Results.Ok(movie);
});

app.MapPatch("/api/movies/{id:guid}/rate", async (Guid id, int raiting) =>
{
    var movie = await movieService.SetRating(id, raiting);
    return Results.Ok(movie);
});

app.MapDelete("/api/movies/{id:guid}", async  (Guid id) =>
{
    await  movieService.DeleteMovieById(id);
    return Results.NoContent();
});



MovieActorService movieActorService = new MovieActorService();

app.MapPost("/api/movies/{movieId:guid}/actors/{actorId:guid}", async (Guid movieId, Guid actorId) =>
{
    var message = await movieActorService.ConnectMovieAndActor(movieId, actorId);
    return Results.Ok(message);
});

app.MapDelete("/api/movies/{movieId:guid}/actors/{actorId:guid}", async (Guid movieId, Guid actorId) =>
{
    await movieActorService.DisconnectMovieAndActor(movieId, actorId);
    return Results.NoContent();
});

app.MapGet("/api/movies/{movieId:guid}/actors", async (Guid movieId) =>
{
    var actor = await movieActorService.GetActorsByMovieId(movieId);
    return Results.Ok(actor);
});

app.Run();
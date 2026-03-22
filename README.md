Movie Tracker API — a RESTful service for managing movies, genres, and actors.

**Project Description**
Movie Tracker API is a backend application built with **ASP.NET Core Minimal API** that allows users to manage a collection of movies.
The application solves the problem of organizing movie data by providing functionality to:
- store movies with genres and actors
- track watched status
- rate movies
- manage relationships between movies and actors

**Technologies**
- **ASP.NET Core Minimal API** — for simplicity and fast development
- **Entity Framework Core** — for working with relational data
- **PostgreSQL (Npgsql)** — as a reliable database
- **Swagger** — for easy API testing and documentation

**Architecture**
The project follows a clean structure with separation of concerns:
- **Domain** — entities (Movie, Actor, Genre, MovieActor)
- **DTOs** — data transfer objects for API responses
- **Infrastructure (EF Core)** — database context and configuration
- **API layer** — endpoints using Minimal API

**Key principles:**
- DTOs are used instead of entities in responses
- Async/await for all database operations
- Proper HTTP status codes

**Challenges**
- Implementing a many-to-many relationship (Movie ↔ Actor)
- Mapping entities to DTOs correctly
- Handling related data loading (Include / joins)

**Example Endpoints**
Create a movie - POST /api/movies
Get all movies - GET /api/movies
Mark movie as watched - PATCH /api/movies/{id}/watch
Rate a movie - PATCH /api/movies/{id}/rate?rating=8
Add actor to movie - POST /api/movies/{movieId}/actors/{actorId}?role=Lead

**Data Structure**
The application uses the following relationships:
- Genre → Movies (1:M)
- Movies ↔ Actors (M:M via MovieActor)

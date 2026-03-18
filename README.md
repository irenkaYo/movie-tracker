# 🎬 Movie Tracker API

A RESTful API for managing movies, genres, and actors.

---

## 🚀 Tech Stack

* ASP.NET Core Minimal API
* Entity Framework Core
* PostgreSQL (Npgsql)
* Swagger

---

## 📊 Database Structure

### Entities

**Genre**

* Id (int, PK)
* Name (string)

**Movie**

* Id (int, PK)
* Title (string)
* Year (int)
* DurationMinutes (int)
* IsWatched (bool)
* Rating (int?, 1–10)
* GenreId (FK)

**Actor**

* Id (int, PK)
* Name (string)
* BirthYear (int)

**MovieActor**

* MovieId (PK, FK)
* ActorId (PK, FK)

📌 Composite Key: (MovieId, ActorId)

---

## 🔗 Relationships

* Genre → Movies (1:M)
* Movies ↔ Actors (M:M)

---

## 📦 DTOs

* GenreDto: Id, Name, MoviesCount
* MovieDto: Id, Title, Year, DurationMinutes, IsWatched, Rating, GenreName, ActorNames
* ActorDto: Id, Name, BirthYear, MoviesCount

---

## 🌐 Endpoints

### 🎭 Genres

* GET /api/genres
* GET /api/genres/{id}
* POST /api/genres
* DELETE /api/genres/{id}

---

### 🎬 Movies

* GET /api/movies
* GET /api/movies/{id}
* GET /api/movies/genre/{genreId}
* POST /api/movies
* PATCH /api/movies/{id}/watch
* PATCH /api/movies/{id}/rate
* DELETE /api/movies/{id}

---

### 👤 Actors

* GET /api/actors
* GET /api/actors/{id}
* POST /api/actors
* DELETE /api/actors/{id}

---

### 🔗 Movie-Actor

* POST /api/movies/{movieId}/actors/{actorId}
* DELETE /api/movies/{movieId}/actors/{actorId}
* GET /api/movies/{movieId}/actors

---

## ✅ Validation Rules

Rating must be between 1 and 10
Year must be between 1000 and 2100
DurationMinutes must be greater than 0
GenreId and ActorId must exist
Duplicate MovieActor relations are not allowed
---

## ⚙️ Requirements

* async/await везде
* DTO вместо моделей
* Include для Genre
* Корректные HTTP статусы 

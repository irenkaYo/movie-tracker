# 🎬 Movie Tracker API

REST API для управления фильмами, жанрами и актёрами.

---

## 🚀 Стек

* ASP.NET Core Minimal API
* Entity Framework Core
* PostgreSQL (Npgsql)
* Swagger

---

## 📊 База данных

### Сущности

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

## 🔗 Связи

* Genre → Movies (1:M)
* Movies ↔ Actors (M:M)

---

## 📦 DTO

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

## ✅ Валидация

* Rating: 1–10
* Year: 1000–2100
* DurationMinutes > 0
* Нельзя добавлять дубликаты MovieActor
* Genre и Actor должны существовать

---

## ⚙️ Требования

* async/await везде
* DTO вместо моделей
* Include для Genre
* Корректные HTTP статусы

---

---

# About the project

This is a simple ASP.Net Core WebAPI Application with PostgreSql database.
Application manages database records of Games and related Categories:
It lists all Games and Categories and lets Add, Edit, Modify or Remove selected Game or Category from the list.
Most of that, Games could be requested by Category Id, and a Category could be added for a Game.
There is a name validation for Games and Categories, because of that you can't add a Game or a Category with the csame name.
Database records CRUD operations are implemented on the Backend side and are accessed through the REST requests.
On the Backend side Database object mapping is fulfilled by Entity Framework.
Application implements Repository Patern in order to separate responsibilities.

## Build with

- ASP.NET 5.0
- Entity Framework Core 5.0
- Automapper 11.0

## Published

The site is published at https://webappext.herokuapp.com/

## REST API

The REST API to the app is described below.

### Get list of Games

`GET api/games/`

### Get a specific Game

`GET api/games/{id}`

### Add a specific Game

`POST api/games/`
with body:
{"name":"...","author":"...", categories:[{"name":"..."}, {"name":"..."}]}

### Edit a specific Game

`PUT api/games/{id}`
with body:
{"name":"...","author":"...", categories:[{"name":"..."}, {"name":"..."}]}

### Remove a specific Game

`DELETE api/games/{id}`

### Get list of Games by the specific Category

`GET api/games/category/{id}`

### Add a Category for a specific Game

`POST api/games/{id}/category`
with body:
{"name":"..."}

### Get list of Categories

`GET api/categories/`

### Get a specific Category

`GET api/categories/{id}`

### Add a specific Category

`POST api/categories/`
with body:
{"name":"..."}

### Edit a specific Category

`PUT api/categories/{id}`
with body:
{"name":"..."}

### Remove a specific Category

`DELETE api/categories/{id}`

# Playlist Manager Web API
> Web API for managing and browsing playlists of videos built with C# .NET Core 5.


## Table of Contents
* [General Info](#general-information)
* [Built With](#built-with)
* [Features](#features)
* [Usage in Visual Studio](#usage)
* [Room for Improvement](#room-for-improvement)


## General Information
* Architecture based on four layers
	- Core: This layer will contain all entities, enums, types and logic specific to the core layer.
	- Application: This layer will contain all application logic and it only dependends on the core layer.
	- Infrastructure: This layer will contain classes for accessing external resources such as file systems and database. These classes should be based on interfaces defined within the application layer.
	- API: This layer is a Web API that which depends on both, Application and Infrastructure layers.
* Application of Mediator Pattern to decrease the dependence and coupling between objects.


## Built With
- .NET Core 5
- C#
- MediatR
- AutoMapper


## Features
* Initial data load on startup
* Basic CRUD using Web API .NET Core 5
	- Create a new playlist
	- Retrieve all playlists
	- Update an existing playlist
	- Delete an existing playlist
	- Add a video to an existing playlist
	- Remove a video from an existing playlist
	- Retrieve all videos in a playlist
	- Retrieve all videos


## Usage in Visual Studio
Open the project, build it, and run it.
The Swagger default start page should be loaded in the browser displaying the following two controllers and their respective endpoints:
* Playlist
	- GET ​/api​/Playlists​/Test: Get test environment (returns `ASPNETCORE_ENVIRONMENT`)
	- GET ​/api​/Playlists: Retrieve all playlists
	- GET ​/api​/Playlists​/{id}​/Videos: Retrieve all videos in a playlist
	- POST ​/api​/Playlists: Create a new playlist
	- PUT ​/api​/Playlists​/{id}: Update an existing playlist
	- PUT ​/api​/Playlists​/AddVideo: Add a video to an existing playlist
	- PUT ​/api​/Playlists​/RemoveVideo: Remove a video from an existing playlist
	- DELETE ​/api​/Playlists​/{id}: Delete an existing playlist

* Video
	- GET ​/api​/Videos​/Test: Get test environment (returns `ASPNETCORE_ENVIRONMENT`)
	- GET ​/api​/Videos: Retrieve all videos


## Room for Improvement
- Unit tests and integration tests
- Permanent storage (database, file)
- Fetching playlist by video ID
- Logging
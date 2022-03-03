# Pet Tracker
CRUD built in .NET CORE 3.1 using native MVC and HTTPCLIENT for PetTracker.Api requests.

## Requirements:

- MySQL configured with port 3036.
- Visual Studio 2019 +.

## Settings
  
- After the project clone, execute the "script.sql" file inside mySQL. It is necessary to create a connection with username "root" and password "123".

## Starting

- In the solution properties (right click) -> Common Properties -> Startup project -> "Multiple startup projects" -> and set PetTracker.Api and PetTracker.Web to run.

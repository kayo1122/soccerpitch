· MD
SoccerPitch

SoccerPitch is an ASP.NET Core MVC web app for building soccer team lineups — create teams, manage rosters, and arrange players on a pitch using a drag-and-drop interface.

Features
Team management — Create, edit, and delete teams through Bootstrap 5 modal forms
Drag-and-drop lineup builder — Position players on an interactive pitch view
Roster CRUD — Add, update, and remove players from a team
Server-rendered Razor views backed by ASP.NET Core MVC controllers
Tech Stack
Backend: ASP.NET Core MVC (C#)
Data access: Entity Framework Core
Frontend: Razor views, Bootstrap 5, vanilla JavaScript (wwwroot/js/soccerpitch.js)
Hosting: SmarterASP.NET
Getting Started
Prerequisites
.NET SDK (matching the version targeted by this project)
SQL Server (LocalDB, full SQL Server, or Azure SQL)
Visual Studio 2022 (recommended) or the dotnet CLI
Setup
Clone the repository
bash
   git clone <repo-url>
   cd SoccerPitch
Update the connection string in appsettings.json to point to your database
Apply EF Core migrations
bash
   dotnet ef database update
Run the app
bash
   dotnet run
Open https://localhost:<port> in your browser
Project Structure
SoccerPitch/
├── Controllers/        # MVC controllers
├── Models/              # EF Core entities / view models
├── Views/               # Razor views (Team CRUD, pitch builder, etc.)
├── wwwroot/
│   └── js/
│       └── soccerpitch.js   # Drag-and-drop and UI logic
└── Data/                # DbContext and migrations
Known Issues / Notes
Azure SQL setup is blocked under the current student subscription's region restrictions; the app currently falls back to hardcoded player data as a workaround
EF Core migrations against the remote (SmarterASP.NET) database are still outstanding
Contributing

This is a group project. Please open a pull request and resolve merge conflicts locally in Visual Studio before pushing to main.

License

Educational project — no license specified.

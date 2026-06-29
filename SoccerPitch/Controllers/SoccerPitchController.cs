using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoccerPitch.Data;
using SoccerPitch.Models;

namespace SoccerPitch.Controllers
{
    public class SoccerPitchController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SoccerPitchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Temporary fake data
            var teams = new List<Team>
    {

    new Team
    {
        TeamId = 1,
        TeamName = "Canada",
        UserId = 1,
        Players = new List<Player>
        {
            // Starters
            new Player { PlayerId = 1,  PlayerName = "Milan Borjan",        PreferredPosition = "GK", OverallRating = 77, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 2,  PlayerName = "Alphonso Davies",     PreferredPosition = "LB", OverallRating = 89, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 3,  PlayerName = "Kamal Miller",        PreferredPosition = "CB", OverallRating = 73, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 4,  PlayerName = "Derek Cornelius",     PreferredPosition = "CB", OverallRating = 72, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 5,  PlayerName = "Richie Laryea",       PreferredPosition = "RB", OverallRating = 74, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 6,  PlayerName = "Stephen Eustaquio",   PreferredPosition = "CM", OverallRating = 78, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 7,  PlayerName = "Atiba Hutchinson",    PreferredPosition = "CM", OverallRating = 75, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 8,  PlayerName = "Samuel Piette",       PreferredPosition = "CM", OverallRating = 71, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 9,  PlayerName = "Tajon Buchanan",      PreferredPosition = "RW", OverallRating = 79, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 10, PlayerName = "Jonathan David",      PreferredPosition = "ST", OverallRating = 85, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 11, PlayerName = "Cyle Larin",          PreferredPosition = "ST", OverallRating = 80, TeamId = 1, TeamName = "Canada" },
            // Subs
            new Player { PlayerId = 12, PlayerName = "Maxime Crepeau",      PreferredPosition = "GK", OverallRating = 72, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 13, PlayerName = "James Pantemis",      PreferredPosition = "GK", OverallRating = 68, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 14, PlayerName = "Alistair Johnston",   PreferredPosition = "RB", OverallRating = 73, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 15, PlayerName = "Doneil Henry",        PreferredPosition = "CB", OverallRating = 69, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 16, PlayerName = "Moïse Bombito",       PreferredPosition = "CB", OverallRating = 70, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 17, PlayerName = "Liam Fraser",         PreferredPosition = "CM", OverallRating = 68, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 18, PlayerName = "David Wotherspoon",   PreferredPosition = "CM", OverallRating = 67, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 19, PlayerName = "Jonathan Osorio",     PreferredPosition = "CM", OverallRating = 72, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 20, PlayerName = "Jacob Shaffelburg",   PreferredPosition = "LW", OverallRating = 70, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 21, PlayerName = "Ballou Tabla",        PreferredPosition = "RW", OverallRating = 68, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 22, PlayerName = "Theo Corbeanu",       PreferredPosition = "LW", OverallRating = 69, TeamId = 1, TeamName = "Canada" },
            new Player { PlayerId = 23, PlayerName = "Lucas Cavallini",     PreferredPosition = "ST", OverallRating = 71, TeamId = 1, TeamName = "Canada" },
        }
    },
    new Team
    {
        TeamId = 2,
        TeamName = "Brazil",
        UserId = 1,
        Players = new List<Player>
        {
            // Starters
            new Player { PlayerId = 24, PlayerName = "Alisson",             PreferredPosition = "GK", OverallRating = 90, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 25, PlayerName = "Alex Sandro",         PreferredPosition = "LB", OverallRating = 79, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 26, PlayerName = "Marquinhos",          PreferredPosition = "CB", OverallRating = 87, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 27, PlayerName = "Militao",             PreferredPosition = "CB", OverallRating = 85, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 28, PlayerName = "Danilo",              PreferredPosition = "RB", OverallRating = 81, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 29, PlayerName = "Casemiro",            PreferredPosition = "CM", OverallRating = 86, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 30, PlayerName = "Lucas Paqueta",       PreferredPosition = "CM", OverallRating = 85, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 31, PlayerName = "Bruno Guimaraes",     PreferredPosition = "CM", OverallRating = 84, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 32, PlayerName = "Rodrygo",             PreferredPosition = "RW", OverallRating = 86, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 33, PlayerName = "Endrick",             PreferredPosition = "ST", OverallRating = 83, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 34, PlayerName = "Vinicius Jr",         PreferredPosition = "LW", OverallRating = 92, TeamId = 2, TeamName = "Brazil" },
            // Subs
            new Player { PlayerId = 35, PlayerName = "Ederson",             PreferredPosition = "GK", OverallRating = 88, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 36, PlayerName = "Weverton",            PreferredPosition = "GK", OverallRating = 75, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 37, PlayerName = "Guilherme Arana",     PreferredPosition = "LB", OverallRating = 78, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 38, PlayerName = "Gabriel Magalhaes",   PreferredPosition = "CB", OverallRating = 83, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 39, PlayerName = "Bremer",              PreferredPosition = "CB", OverallRating = 82, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 40, PlayerName = "Yan Couto",           PreferredPosition = "RB", OverallRating = 76, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 41, PlayerName = "Gerson",              PreferredPosition = "CM", OverallRating = 80, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 42, PlayerName = "Andreas Pereira",     PreferredPosition = "CM", OverallRating = 77, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 43, PlayerName = "Gabriel Martinelli",  PreferredPosition = "LW", OverallRating = 83, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 44, PlayerName = "Savinho",             PreferredPosition = "RW", OverallRating = 79, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 45, PlayerName = "Gabriel",             PreferredPosition = "ST", OverallRating = 84, TeamId = 2, TeamName = "Brazil" },
            new Player { PlayerId = 46, PlayerName = "Richarlison",         PreferredPosition = "ST", OverallRating = 82, TeamId = 2, TeamName = "Brazil" },
        }
    },
    new Team
    {
        TeamId = 3,
        TeamName = "Portugal",
        UserId = 1,
        Players = new List<Player>
        {
            // Starters
            new Player { PlayerId = 47, PlayerName = "Diogo Costa",         PreferredPosition = "GK", OverallRating = 85, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 48, PlayerName = "Nuno Mendes",         PreferredPosition = "LB", OverallRating = 84, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 49, PlayerName = "Ruben Dias",          PreferredPosition = "CB", OverallRating = 90, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 50, PlayerName = "Antonio Silva",       PreferredPosition = "CB", OverallRating = 82, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 51, PlayerName = "Joao Cancelo",        PreferredPosition = "RB", OverallRating = 86, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 52, PlayerName = "Vitinha",             PreferredPosition = "CM", OverallRating = 84, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 53, PlayerName = "Joao Palhinha",       PreferredPosition = "CM", OverallRating = 85, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 54, PlayerName = "Bruno Fernandes",     PreferredPosition = "CM", OverallRating = 88, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 55, PlayerName = "Bernardo Silva",      PreferredPosition = "RW", OverallRating = 88, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 56, PlayerName = "Cristiano Ronaldo",   PreferredPosition = "ST", OverallRating = 88, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 57, PlayerName = "Rafael Leao",         PreferredPosition = "LW", OverallRating = 86, TeamId = 3, TeamName = "Portugal" },
            // Subs
            new Player { PlayerId = 58, PlayerName = "Rui Patricio",        PreferredPosition = "GK", OverallRating = 82, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 59, PlayerName = "Jose Sa",             PreferredPosition = "GK", OverallRating = 78, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 60, PlayerName = "Joao Gomes",          PreferredPosition = "CM", OverallRating = 78, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 61, PlayerName = "Matheus Nunes",       PreferredPosition = "CM", OverallRating = 79, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 62, PlayerName = "Danilo Pereira",      PreferredPosition = "CB", OverallRating = 78, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 63, PlayerName = "Nelson Semedo",       PreferredPosition = "RB", OverallRating = 80, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 64, PlayerName = "Diogo Dalot",         PreferredPosition = "RB", OverallRating = 81, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 65, PlayerName = "Pepe",                PreferredPosition = "CB", OverallRating = 76, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 66, PlayerName = "Francisco Conceicao", PreferredPosition = "RW", OverallRating = 80, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 67, PlayerName = "Goncalo Ramos",       PreferredPosition = "ST", OverallRating = 82, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 68, PlayerName = "Joao Felix",          PreferredPosition = "ST", OverallRating = 83, TeamId = 3, TeamName = "Portugal" },
            new Player { PlayerId = 69, PlayerName = "Pedro Neto",          PreferredPosition = "LW", OverallRating = 81, TeamId = 3, TeamName = "Portugal" },
        }
    },
    new Team
    {
        TeamId = 4,
        TeamName = "Argentina",
        UserId = 1,
        Players = new List<Player>
        {
            // Starters
            new Player { PlayerId = 70, PlayerName = "Emiliano Martinez",   PreferredPosition = "GK", OverallRating = 88, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 71, PlayerName = "Marcos Acuna",        PreferredPosition = "LB", OverallRating = 82, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 72, PlayerName = "Lisandro Martinez",   PreferredPosition = "CB", OverallRating = 85, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 73, PlayerName = "Cristian Romero",     PreferredPosition = "CB", OverallRating = 86, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 74, PlayerName = "Gonzalo Montiel",     PreferredPosition = "RB", OverallRating = 80, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 75, PlayerName = "Rodrigo De Paul",     PreferredPosition = "CM", OverallRating = 84, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 76, PlayerName = "Enzo Fernandez",      PreferredPosition = "CM", OverallRating = 85, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 77, PlayerName = "Lionel Messi",        PreferredPosition = "RW", OverallRating = 94, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 78, PlayerName = "Nicolas Gonzalez",    PreferredPosition = "LW", OverallRating = 82, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 79, PlayerName = "Lautaro Martinez",    PreferredPosition = "ST", OverallRating = 88, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 80, PlayerName = "Alejandro Garnacho",  PreferredPosition = "LW", OverallRating = 82, TeamId = 4, TeamName = "Argentina" },
            // Subs
            new Player { PlayerId = 81, PlayerName = "Franco Armani",       PreferredPosition = "GK", OverallRating = 80, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 82, PlayerName = "Geronimo Rulli",      PreferredPosition = "GK", OverallRating = 76, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 83, PlayerName = "German Pezzella",     PreferredPosition = "CB", OverallRating = 77, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 84, PlayerName = "Facundo Medina",      PreferredPosition = "CB", OverallRating = 75, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 85, PlayerName = "Nahuel Molina",       PreferredPosition = "RB", OverallRating = 81, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 86, PlayerName = "Nicolas Tagliafico",  PreferredPosition = "LB", OverallRating = 78, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 87, PlayerName = "Guido Rodriguez",     PreferredPosition = "CM", OverallRating = 78, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 88, PlayerName = "Exequiel Palacios",   PreferredPosition = "CM", OverallRating = 77, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 89, PlayerName = "Angel Di Maria",      PreferredPosition = "RW", OverallRating = 82, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 90, PlayerName = "Paulo Dybala",        PreferredPosition = "ST", OverallRating = 84, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 91, PlayerName = "Julian Alvarez",      PreferredPosition = "ST", OverallRating = 86, TeamId = 4, TeamName = "Argentina" },
            new Player { PlayerId = 92, PlayerName = "Thiago Almada",       PreferredPosition = "CM", OverallRating = 76, TeamId = 4, TeamName = "Argentina" },
        }
    }
};

            return View(teams);
        }

        [HttpPost]
        public IActionResult SaveLineup([FromBody] LineupSubmission submission)
        {
            if (submission == null || submission.Players == null)
                return Json(new { success = false, message = "No lineup data received." });

            //  save to DB here later 
            return Json(new { success = true, message = $"Lineup saved! Formation: {submission.Formation}" });
        }
    }

    // DTO for lineup submission
    public class LineupSubmission
    {
        public string Formation { get; set; } = string.Empty;
        public List<LineupPlayer> Players { get; set; } = new();
    }

    public class LineupPlayer
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string SlotId { get; set; } = string.Empty;
    }
}

using SoccerPitch.Models;

namespace SoccerPitch.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {

            if (context.Teams.Any())
            {
                return;
            }



            var teams = new List<Team>
            {

                new Team
                {
                    TeamName = "Canada",
                    UserId = 1,

                    Players = new List<Player>
                    {
            // Starters
            new Player {PlayerName = "Milan Borjan", PreferredPosition = "GK", OverallRating = 77},
            new Player {PlayerName = "Alphonso Davies", PreferredPosition = "LB", OverallRating = 89},
            new Player {PlayerName = "Kamal Miller", PreferredPosition = "CB", OverallRating = 73},
            new Player {PlayerName = "Derek Cornelius", PreferredPosition = "CB", OverallRating = 72},
            new Player {PlayerName = "Richie Laryea", PreferredPosition = "RB", OverallRating = 74},
            new Player {PlayerName = "Stephen Eustaquio", PreferredPosition = "CM", OverallRating = 78},
            new Player {PlayerName = "Atiba Hutchinson", PreferredPosition = "CM", OverallRating = 75},
            new Player {PlayerName = "Samuel Piette", PreferredPosition = "CM", OverallRating = 71},
            new Player {PlayerName = "Tajon Buchanan", PreferredPosition = "RW", OverallRating = 79},
            new Player {PlayerName = "Jonathan David", PreferredPosition = "ST", OverallRating = 85},
            new Player {PlayerName = "Cyle Larin", PreferredPosition = "ST", OverallRating = 80},
            // Subs
            new Player {PlayerName = "Maxime Crepeau", PreferredPosition = "GK", OverallRating = 72},
            new Player {PlayerName = "James Pantemis", PreferredPosition = "GK", OverallRating = 68},
            new Player {PlayerName = "Alistair Johnston", PreferredPosition = "RB", OverallRating = 73},
            new Player {PlayerName = "Doneil Henry", PreferredPosition = "CB", OverallRating = 69},
            new Player {PlayerName = "Moïse Bombito", PreferredPosition = "CB", OverallRating = 70},
            new Player {PlayerName = "Liam Fraser", PreferredPosition = "CM", OverallRating = 68},
            new Player {PlayerName = "David Wotherspoon", PreferredPosition = "CM", OverallRating = 67},
            new Player {PlayerName = "Jonathan Osorio", PreferredPosition = "CM", OverallRating = 72},
            new Player {PlayerName = "Jacob Shaffelburg", PreferredPosition = "LW", OverallRating = 70},
            new Player {PlayerName = "Ballou Tabla", PreferredPosition = "RW", OverallRating = 68},
            new Player {PlayerName = "Theo Corbeanu", PreferredPosition = "LW", OverallRating = 69},
            new Player {PlayerName = "Lucas Cavallini", PreferredPosition = "ST", OverallRating = 71},


                    }
                },



                new Team
                {
                    TeamName = "Brazil",
                    UserId = 1,

                    Players = new List<Player>
                    {
            // Starters
            new Player {PlayerName = "Alisson", PreferredPosition = "GK", OverallRating = 90},
            new Player {PlayerName = "Alex Sandro", PreferredPosition = "LB", OverallRating = 79},
            new Player {PlayerName = "Marquinhos", PreferredPosition = "CB", OverallRating = 87},
            new Player {PlayerName = "Militao", PreferredPosition = "CB", OverallRating = 85},
            new Player {PlayerName = "Danilo", PreferredPosition = "RB", OverallRating = 81},
            new Player {PlayerName = "Casemiro", PreferredPosition = "CM", OverallRating = 86},
            new Player {PlayerName = "Lucas Paqueta", PreferredPosition = "CM", OverallRating = 85},
            new Player {PlayerName = "Bruno Guimaraes", PreferredPosition = "CM", OverallRating = 84},
            new Player {PlayerName = "Rodrygo", PreferredPosition = "RW", OverallRating = 86},
            new Player {PlayerName = "Endrick", PreferredPosition = "ST", OverallRating = 83},
            new Player {PlayerName = "Vinicius Jr", PreferredPosition = "LW", OverallRating = 92},
            // Subs
            new Player {PlayerName = "Ederson", PreferredPosition = "GK", OverallRating = 88},
            new Player {PlayerName = "Weverton", PreferredPosition = "GK", OverallRating = 75},
            new Player {PlayerName = "Guilherme Arana", PreferredPosition = "LB", OverallRating = 78},
            new Player {PlayerName = "Gabriel Magalhaes", PreferredPosition = "CB", OverallRating = 83},
            new Player {PlayerName = "Bremer", PreferredPosition = "CB", OverallRating = 82},
            new Player {PlayerName = "Yan Couto", PreferredPosition = "RB", OverallRating = 76},
            new Player {PlayerName = "Gerson", PreferredPosition = "CM", OverallRating = 80},
            new Player {PlayerName = "Andreas Pereira", PreferredPosition = "CM", OverallRating = 77},
            new Player {PlayerName = "Gabriel Martinelli", PreferredPosition = "LW", OverallRating = 83},
            new Player {PlayerName = "Savinho", PreferredPosition = "RW", OverallRating = 79},
            new Player {PlayerName = "Gabriel", PreferredPosition = "ST", OverallRating = 84},
            new Player {PlayerName = "Richarlison", PreferredPosition = "ST", OverallRating = 82},


                    }
                },



                new Team
                {
                    TeamName = "Portugal",
                    UserId = 1,

                    Players = new List<Player>
                    {

            // Starters
            new Player {PlayerName = "Diogo Costa",         PreferredPosition = "GK", OverallRating = 85 },
            new Player {PlayerName = "Nuno Mendes", PreferredPosition = "LB", OverallRating = 84},
            new Player {PlayerName = "Ruben Dias", PreferredPosition = "CB", OverallRating = 90},
            new Player {PlayerName = "Antonio Silva", PreferredPosition = "CB", OverallRating = 82},
            new Player {PlayerName = "Joao Cancelo", PreferredPosition = "RB", OverallRating = 86},
            new Player {PlayerName = "Vitinha", PreferredPosition = "CM", OverallRating = 84},
            new Player {PlayerName = "Joao Palhinha", PreferredPosition = "CM", OverallRating = 85},
            new Player {PlayerName = "Bruno Fernandes", PreferredPosition = "CM", OverallRating = 88},
            new Player {PlayerName = "Bernardo Silva", PreferredPosition = "RW", OverallRating = 88},
            new Player {PlayerName = "Cristiano Ronaldo", PreferredPosition = "ST", OverallRating = 88},
            new Player {PlayerName = "Rafael Leao", PreferredPosition = "LW", OverallRating = 86},
            // Subs
            new Player {PlayerName = "Rui Patricio", PreferredPosition = "GK", OverallRating = 82},
            new Player {PlayerName = "Jose Sa", PreferredPosition = "GK", OverallRating = 78},
            new Player {PlayerName = "Joao Gomes", PreferredPosition = "CM", OverallRating = 78},
            new Player {PlayerName = "Matheus Nunes", PreferredPosition = "CM", OverallRating = 79},
            new Player {PlayerName = "Danilo Pereira", PreferredPosition = "CB", OverallRating = 78},
            new Player {PlayerName = "Nelson Semedo", PreferredPosition = "RB", OverallRating = 80},
            new Player {PlayerName = "Diogo Dalot", PreferredPosition = "RB", OverallRating = 81},
            new Player {PlayerName = "Pepe", PreferredPosition = "CB", OverallRating = 76},
            new Player {PlayerName = "Francisco Conceicao", PreferredPosition = "RW", OverallRating = 80},
            new Player {PlayerName = "Goncalo Ramos", PreferredPosition = "ST", OverallRating = 82},
            new Player {PlayerName = "Joao Felix", PreferredPosition = "ST", OverallRating = 83},
            new Player {PlayerName = "Pedro Neto", PreferredPosition = "LW", OverallRating = 81},

                    }
                },



                new Team
                {
                    TeamName = "Argentina",
                    UserId = 1,

                    Players = new List<Player>
                    {
            // Starters
            new Player {PlayerName = "Emiliano Martinez",   PreferredPosition = "GK", OverallRating = 88, },
            new Player {PlayerName = "Marcos Acuna",        PreferredPosition = "LB", OverallRating = 82, },
            new Player {PlayerName = "Lisandro Martinez", PreferredPosition = "CB", OverallRating = 85},
            new Player {PlayerName = "Cristian Romero", PreferredPosition = "CB", OverallRating = 86},
            new Player {PlayerName = "Gonzalo Montiel", PreferredPosition = "RB", OverallRating = 80},
            new Player {PlayerName = "Rodrigo De Paul", PreferredPosition = "CM", OverallRating = 84},
            new Player {PlayerName = "Enzo Fernandez", PreferredPosition = "CM", OverallRating = 85},
            new Player {PlayerName = "Lionel Messi", PreferredPosition = "RW", OverallRating = 94},
            new Player {PlayerName = "Nicolas Gonzalez", PreferredPosition = "LW", OverallRating = 82},
            new Player {PlayerName = "Lautaro Martinez", PreferredPosition = "ST", OverallRating = 88},
            new Player {PlayerName = "Alejandro Garnacho", PreferredPosition = "LW", OverallRating = 82},
            // Subs
            new Player {PlayerName = "Franco Armani", PreferredPosition = "GK", OverallRating = 80},
            new Player {PlayerName = "Geronimo Rulli", PreferredPosition = "GK", OverallRating = 76},
            new Player {PlayerName = "German Pezzella", PreferredPosition = "CB", OverallRating = 77},
            new Player {PlayerName = "Facundo Medina", PreferredPosition = "CB", OverallRating = 75},
            new Player {PlayerName = "Nahuel Molina", PreferredPosition = "RB", OverallRating = 81},
            new Player {PlayerName = "Nicolas Tagliafico", PreferredPosition = "LB", OverallRating = 78},
            new Player {PlayerName = "Guido Rodriguez", PreferredPosition = "CM", OverallRating = 78},
            new Player {PlayerName = "Exequiel Palacios", PreferredPosition = "CM", OverallRating = 77},
            new Player {PlayerName = "Angel Di Maria", PreferredPosition = "RW", OverallRating = 82},
            new Player {PlayerName = "Paulo Dybala", PreferredPosition = "ST", OverallRating = 84},
            new Player {PlayerName = "Julian Alvarez", PreferredPosition = "ST", OverallRating = 86},
            new Player {PlayerName = "Thiago Almada", PreferredPosition = "CM", OverallRating = 76},


                    }
                }

            };



            context.Teams.AddRange(teams);

            context.SaveChanges();

        }
    }
}

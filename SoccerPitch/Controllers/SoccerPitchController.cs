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
            var teams = _context.Teams
                .Include(t => t.Players)
                .ToList();

            return View(teams);
        }

        [HttpPost]
        public IActionResult SaveLineup([FromBody] LineupSubmission submission)
        {
            if (submission == null || submission.Players == null)
                return Json(new { success = false, message = "No lineup data received." });

            return Json(new { success = true, message = $"Lineup saved! Formation: {submission.Formation}" });
        }

        // EDIT TEAM
        public IActionResult Edit(int id)
        {
            var team = _context.Teams
                .Include(t => t.Players)
                .FirstOrDefault(t => t.TeamId == id);

            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        [HttpPost]
        public IActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Teams.Update(team);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(team);
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
}
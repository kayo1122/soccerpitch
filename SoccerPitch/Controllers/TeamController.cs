using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SoccerPitch.Data;
using SoccerPitch.Models;
using Microsoft.EntityFrameworkCore;
namespace SoccerPitch.Controllers;

public class TeamController : Controller
{
    // Gets a db context 
    private readonly ApplicationDbContext _context;

    public TeamController(ApplicationDbContext context)
    {
        _context = context;
    }

    // returns the Create View
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // returns the Edit view
    [HttpGet]
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

    // actual creating of a team
    [HttpPost]
    public IActionResult Create(Team team)
    {
        if (team.Players != null)
        {
            team.Players = team.Players.Where(p => !string.IsNullOrWhiteSpace(p.PlayerName)).ToList();
        }
        // if something is missing then it reloads the page
        if (!ModelState.IsValid)
        {
            return View(team);
        }

        // user can create only unique teams 
        if (_context.Teams.Any(t => t.TeamName == team.TeamName))
        {
            ModelState.AddModelError("", "Team already exists");
            return View(team);
        }

        // adds team to db
        _context.Teams.Add(team);
        _context.SaveChanges();
        // redirects to the main page
        return RedirectToAction("Index", "SoccerPitch");
    }

    // [post method for edit
    [HttpPost]
    public IActionResult Edit(Team team)
    {
        if (team.Players != null)
        {
            // Filters the collection to keep only players who have a valid name
            team.Players = team.Players.Where(p => !string.IsNullOrWhiteSpace(p.PlayerName)).ToList();
        }
        if (ModelState.IsValid)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();

            return RedirectToAction("Index", "SoccerPitch");
        }

        return View(team);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var team = _context.Teams
            .Include(t => t.Players)
            .FirstOrDefault(t => t.TeamId == id);

        if (team == null)
        {
            return NotFound();
        }
        _context.Teams.Remove(team);
        _context.SaveChanges();

        return RedirectToAction("Index", "SoccerPitch");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddPlayer([FromBody] Player player)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return Json(player);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePlayer(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null) return NotFound();

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
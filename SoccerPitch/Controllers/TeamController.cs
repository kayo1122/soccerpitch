using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SoccerPitch.Data;
using SoccerPitch.Models;

namespace SoccerPitch.Controllers;

public class TeamController : Controller
{
    // Gets a db context 
    private readonly ApplicationDbContext _context;
    public TeamController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // returns a Create View
    [HttpGet] 
    public IActionResult Create()
    {
        return View();
    }

    // actual creating of a team
    [HttpPost]
    public IActionResult Create(Team team)
    {
        // if something is missing then it reloads the page
        if (!ModelState.IsValid)
        {
            return View(team);
        }
        // user can create only unique teams 
        if (_context.Teams.Any(t => t.TeamName == team.TeamName))
        {
            ModelState.AddModelError("","Team already exists");
            return View(team);
        }
        // adds team to db
        _context.Teams.Add(team);
        _context.SaveChanges();
        // redirects to the main page
        return RedirectToAction("Index", "SoccerPitch");
    } 
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoccerPitch.Data;
using SoccerPitch.Models;

namespace SoccerPitch.Controllers;

public class AccountController : Controller
{
    //UPD: added db context
    private readonly ApplicationDbContext _context;
    public AccountController(ApplicationDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    // Returns Login view page
    public IActionResult Login()
    {
        return View();
    }
    
    // Returns Register view page
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // Once users press register button this method works
    [HttpPost]
    public IActionResult Register(User user, string confirmPassword)
    {
        if (!ModelState.IsValid)
            return View(user);
        if (user.Password != confirmPassword)
        {
            ModelState.AddModelError("", "Passwords do not match");
            return View(user);
        }
        
        // UPD, added username and email uniqueness validation
        if (_context.Users.Any(u => u.Email == user.Email))
        {
            ModelState.AddModelError("", "Email is already taken");
            return View(user);
        }

        if (_context.Users.Any(u => u.Username == user.Username))
        {
            ModelState.AddModelError("", "Username is already taken");
            return View(user);
        }
        
        var hasher = new PasswordHasher<User>();
        user.Password = hasher.HashPassword(user, user.Password);
        //UPD added user to db
        _context.Users.Add(user);
        _context.SaveChanges();
        return RedirectToAction("Login");
    }
    
    // Done login method
    [HttpPost]
    public IActionResult Login(string login, string password)
    {
        if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
        {
            ModelState.AddModelError("", "Missing login or password");
            return View();
        }
        var user = _context.Users.FirstOrDefault(u => u.Email == login)
                   ?? _context.Users.FirstOrDefault(u => u.Username == login);
        if (user == null)
        {
                ModelState.AddModelError("", "No user found");
                return View();
        }
        var hasher = new PasswordHasher<User>();
        var result = hasher.VerifyHashedPassword(user, user.Password, password);
        if (result == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError("", "Invalid password");
            return View();
        }
        return RedirectToAction("Index", "Home");
    }
}
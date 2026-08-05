using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoccerPitch.Data;
using SoccerPitch.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
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
        HttpContext.Session.SetString("LoggedInUser", user.Username);
        return RedirectToAction("Index", "SoccerPitch");
    }
    [HttpPost]
    public IActionResult ExternalLogin(string provider, string action)
    {
        var redirectUrl = Url.Action(
            "ExternalLoginCallback",
            "Account",
            new { action = action, provider = provider }
        );

        var properties = new AuthenticationProperties
        {
            RedirectUri = redirectUrl
        };

        return Challenge(properties, provider);
    }
    [HttpGet]
    public async Task<IActionResult> ExternalLoginCallback(string action, string provider)
    {
        var result = await HttpContext.AuthenticateAsync(
            "Identity.External"
        );

        if (!result.Succeeded)
        {
            return RedirectToAction("Login");
        }

        var email = result.Principal.FindFirstValue(ClaimTypes.Email);
        var name = result.Principal.FindFirstValue(ClaimTypes.Name);
        var providerId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

        if (email == null)
        {
            return RedirectToAction("Login");
        }

        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (action == "register")
        {
            if (user != null)
            {
                return RedirectToAction("Login");
            }

            user = new User
            {
                Email = email,
                Username = name ?? email.Split('@')[0],
                Password = string.Empty,
                Provider = provider,
                ProviderId = providerId
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }
        else
        {
            if (user == null)
            {
                return RedirectToAction("Register");
            }
        }

        HttpContext.Session.SetString(
            "LoggedInUser",
            user.Username
        );

        return RedirectToAction("Index", "SoccerPitch");
    }
}
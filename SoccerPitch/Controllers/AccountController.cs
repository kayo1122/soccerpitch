using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SoccerPitch.Models;

namespace SoccerPitch.Controllers;

public class AccountController : Controller
{
    //TODO: Add context, can't do this since I'm a MacBook user
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
        
        // TODO: Check for existing user, can't do it personally since I can't run migrations on MacBook
        
        var hasher = new PasswordHasher<User>();
        user.Password = hasher.HashPassword(user, user.Password);
        //TODO: Save user's hashed password to db instead of plain text
        
        return View(user);
    }

    // TODO: Login post method, can't do it so far since gotta have context to make it actually work
}
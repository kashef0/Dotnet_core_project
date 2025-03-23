using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortfolioApp.Models;
using portofilioApp.Data;
using portofilioApp.Models;

namespace portofilioApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger,  ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> IndexAsync()
    {
        ViewData["Title"] = "Hemsida";

        var viewModel = new HomeViewModel
            {
                UserProfile = await _context.UserProfiles.ToListAsync(),
                Skills = await _context.Skills.ToListAsync(),
                About = await _context.About.ToListAsync(),
                Services = await _context.Services.ToListAsync(),
                Projects = await _context.Projects.ToListAsync(),
                Experiences = await _context.Experiences.ToListAsync(),
                ContactInfo = await _context.ContactInfo.ToListAsync(),
                SocialLinks = await _context.SocialLinks.ToListAsync(),
                Contacts = await _context.Contacts.ToListAsync()
            };
        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

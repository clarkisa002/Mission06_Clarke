using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Clarke.Models;
using SQLitePCL;

namespace Mission06_Clarke.Controllers;

public class HomeController : Controller
{

    private MovieSubmissionContext _context;

    public HomeController(MovieSubmissionContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult AboutJoel()
    {
        return View();
    }
    [HttpGet]
    public IActionResult SubmitMovie()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitMovie(MovieSubmission response)
    {
        _context.MovieSubmissions.Add(response);
        
        return View("Index");
    }
    
}
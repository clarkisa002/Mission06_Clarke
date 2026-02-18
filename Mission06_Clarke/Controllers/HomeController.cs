using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Clarke.Models;

namespace Mission06_Clarke.Controllers;

public class HomeController : Controller
{

    private MovieSubmissionContext _context;

    public HomeController(MovieSubmissionContext temp) //Constructor
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
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View();
    }

    [HttpPost]
    public IActionResult SubmitMovie(MovieSubmission response)
    {
        // Category is optional; don't let validation errors on it block saves
        foreach (var key in ModelState.Keys.Where(k => k.EndsWith(nameof(MovieSubmission.CategoryId)) || k.EndsWith(nameof(MovieSubmission.Category))))
        {
            ModelState[key].Errors.Clear();
        }

        if (ModelState.IsValid)
        {
            _context.MovieSubmissions.Add(response); //Add record to the database
            _context.SaveChanges();
            
            return RedirectToAction("CollectionList");
        }

        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View(response);
    }
    
    public IActionResult CollectionList()
    {
        var submissions = _context.MovieSubmissions
            .Include(x => x.Category)
            .OrderBy(x => x.Title)
            .ToList(); // Execute the query
    
        return View(submissions);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.MovieSubmissions.FirstOrDefault(x => x.MovieId == id);
        if (movie == null)
        {
            return NotFound();
        }

        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View(movie);
    }

    [HttpPost]
    public IActionResult Edit(MovieSubmission updatedMovie)
    {
        // Category is optional; don't let validation errors on it block saves
        foreach (var key in ModelState.Keys.Where(k => k.EndsWith(nameof(MovieSubmission.CategoryId)) || k.EndsWith(nameof(MovieSubmission.Category))))
        {
            ModelState[key].Errors.Clear();
        }

        if (ModelState.IsValid)
        {
            var movie = _context.MovieSubmissions.FirstOrDefault(x => x.MovieId == updatedMovie.MovieId);
            if (movie == null)
            {
                return NotFound();
            }

            movie.CategoryId = updatedMovie.CategoryId;
            movie.Title = updatedMovie.Title;
            movie.Year = updatedMovie.Year;
            movie.Director = updatedMovie.Director;
            movie.Rating = updatedMovie.Rating;
            movie.Edited = updatedMovie.Edited;
            movie.CopiedToPlex = updatedMovie.CopiedToPlex;
            movie.LentTo = updatedMovie.LentTo;
            movie.Notes = updatedMovie.Notes;

            _context.SaveChanges();
            return RedirectToAction("CollectionList");
        }

        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View(updatedMovie);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var movie = _context.MovieSubmissions.FirstOrDefault(x => x.MovieId == id);
        if (movie != null)
        {
            _context.MovieSubmissions.Remove(movie);
            _context.SaveChanges();
        }

        return RedirectToAction("CollectionList");
    }
}
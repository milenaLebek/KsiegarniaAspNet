using System.Diagnostics;
using Ksiegarnia.Data;
using Microsoft.AspNetCore.Mvc;
using Ksiegarnia.Models;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var books = _context.Books.Include(b => b.Author).Include(b => b.Genre).ToList();
        var authors = _context.Authors.ToList();
        var genres = _context.Genres.ToList();

        ViewBag.Books = books;
        ViewBag.Authors = authors;
        ViewBag.Genres = genres;

        return View();
    }
}
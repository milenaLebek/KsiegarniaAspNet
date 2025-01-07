using System.Diagnostics;
using Ksiegarnia.Data;
using Microsoft.AspNetCore.Mvc;
using Ksiegarnia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Ksiegarnia.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var books = _context.Books.Include(b => b.Author).Include(b => b.Genre).ToList();

        ViewBag.Books = books;
        return View();
    }
}
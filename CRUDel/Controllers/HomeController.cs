using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDel.Models;

namespace CRUDel.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        List<Dish> listaDishes = _context.Dishes.OrderByDescending(i => i.DishId).ToList();

        return View(listaDishes);
    }

    [HttpGet("dishes/{DishId}")]
    public IActionResult ShowDish(int DishId)
    {
        Dish oneDish = _context.Dishes.FirstOrDefault(a => a.DishId == DishId);
        return View(oneDish);
    }

    [HttpGet("dishes/new")]
    public IActionResult AddDish()
    {
        return View();
    }

    [HttpPost("dishes/new")]
    public IActionResult AddDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }

    [HttpGet("dishes/{DishId}/edit")]
    public IActionResult EditDish(int DishId)
    {
        Dish? dishToEdit = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);

        return View(dishToEdit);
    }

    [HttpPost("dishes/{DishId}/update")]
    public IActionResult UpdateDish(Dish newDish, int DishId)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(i => i.DishId == DishId);

        if (ModelState.IsValid)
        {
            OldDish.Name = newDish.Name;
            OldDish.Chef = newDish.Chef;
            OldDish.Tastiness = newDish.Tastiness;
            OldDish.Calories = newDish.Calories;
            OldDish.Description = newDish.Description;

            OldDish.UpdatedAt = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("ShowDish", new { DishId });
        }
        else
        {
            return View("EditDish", OldDish);
        }
    }

    [HttpGet("dishes/{DishId}/destroy")]
    [HttpPost("dishes/{DishId}/destroy")]
    public IActionResult DestroyDish(int DishId)
    {
        Dish? dishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == DishId);

        _context.Dishes.Remove(dishToDelete);
        _context.SaveChanges();

        return RedirectToAction("Index");
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

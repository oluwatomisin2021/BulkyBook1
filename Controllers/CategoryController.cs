
using BulkyBook1.Data;
using Microsoft.AspNetCore.Mvc;
namespace BulkyBook1.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    public CategoryController(ApplicationDbContext db)
    {
        _db = db; 
    }
    public IActionResult Index()
    {
        IEnumerable<Category> obj = _db.Categories;
        return View(obj); 
    }
}
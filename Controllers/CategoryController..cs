
using Microsoft.AspNetCore.Mvc;
namespace BulkyBook1.Controllers;

public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View(); 
    }
}

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

    //GET
    public IActionResult Create()
    {
        return View();
    }

    //POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
        if (obj.Name == obj.DisplayOrder.ToString())
        {
            ModelState.AddModelError("displayorder","Order name and Display order must not match");
        }
        if (ModelState.IsValid)
        {
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Created";
            return RedirectToAction("Index");
        }

        return View(obj);
        
    }

    //GET
    public IActionResult Edit(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }

        var categoryFromDb = _db.Categories.Find(id);

        if (categoryFromDb == null)
        {
            return NotFound();
        }

        return View(categoryFromDb);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category category)
    {
        if(category.Name == category.DisplayOrder.ToString())
        {
            ModelState.AddModelError("displayorder","Display order must not match order name");
        }

        if(ModelState.IsValid)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["success"] = "Edit Successful";
            return RedirectToAction("Index");
        }       
        return View(category);
    }
    
    public IActionResult Delete(int? id)
    {
        var objToDelete = _db.Categories.Find(id);
        if (objToDelete == null)
        {
            return NotFound();
        }

        return View(objToDelete);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePOST(int? id)
    {
        var category = _db.Categories.Find(id);
        if(category == null)
        {
            return NotFound();
        }
        _db.Categories.Remove(category);
        _db.SaveChanges();
        TempData["success"] = "Category Deleted";
        return RedirectToAction("Index");
    }
}
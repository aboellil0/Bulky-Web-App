using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {


        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        //to post the new item make another model that have the same name with post method
        //and pase the category that have type of Category
        [HttpPost]
        public IActionResult Create(Category category)
        {
            //adding a custom validation for server side only 
            //if name of category = to display order of category
            if (category.Name == category.DisplayOrder.ToString())
            {
                //------------key for how want to display error for-----the error
                ModelState.AddModelError("name", "name cannot be the same as display order");
            }
            if (category.Name != null && category.Name.ToLower() == "test")
            {
                //error cane be display in model noly or in all 
                ModelState.AddModelError("", "name can not be test");
            }
            if (ModelState.IsValid)
            {
                //adding new category to database in Category table
                _db.Categories.Add(category);
                //if you ready to execuute this statments then save changes
                _db.SaveChanges();
                //create a messege to print that the data crated successfully 
                TempData["success"] = "Category created successfully";
                //redirict to -----------view----Controller-----if you in the same Controler may not write the Controller
                return RedirectToAction("Index", "Category");
            }
            //if is not valid stay in the same view
            return View();
        }




        //Edit

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //all ways to find the category : --------
       
            //using find : working only in primary key
            Category? categoryFromDB = _db.Categories.Find(id);
            //using FirstOrDefault : you can use alot of methods
            
            Category? categoryFromDB1 = _db.Categories.FirstOrDefault(u=>u.CategoryId == id);
            //Category? categoryFromDB1 = _db.Categories.FirstOrDefault(u => u.Name == "aboellil");
            
            //using where :
            Category? categoryFromDB2 = _db.Categories.Where(u=>u.CategoryId==id).FirstOrDefault();
            


            if (categoryFromDB == null)
            {
                return NotFound();
            }
 
            return View(categoryFromDB);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            //exactly like create controller but with using update not add
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }



        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = _db.Categories.Find(id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? categoryFromDB = _db.Categories.Find(id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryFromDB);
            _db.SaveChanges();
            TempData["success"] = "Category removed successfully";
            return RedirectToAction("Index");
        }

    }
}

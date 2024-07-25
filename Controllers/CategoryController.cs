using Microsoft.AspNetCore.Mvc;
using BulkyBookWeb.Models;
using BulkyBookWeb.Data;
using BulkyBookWeb.Repository.IRepository;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;
        public CategoryController(ICategoryRepository db)
        {
            _db = db;
                
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCatagoriesList = _db.GetAll();
            return View(objCatagoriesList);
        }

        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name==obj.DetailsOrder.ToString())
            {
                ModelState.AddModelError("Name", " it is invalid name");
            }
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "user saved successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int ? id)

        {
            if (id == null|| id==0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryfromdbfirst = _db.GetFirstOrDefault(x => x.Id == id);
            //var categoryFromDbSingle= _db.Categories.SingleOrDefault(x => x.Id == id);
            if (categoryfromdbfirst == null)
            {
                return NotFound();
            }

            return View(categoryfromdbfirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DetailsOrder.ToString())
            {
                ModelState.AddModelError("Name", " it is invalid name");
            }
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "user update successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)

        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.GetFirstOrDefault(x => x.Id == id);
            //var categoryFromDbSingle= _db.Categories.SingleOrDefault(x => x.Id == id);
            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int?id)
        {
            var obj = _db.GetFirstOrDefault(x => x.Id == id);
            if (obj == null) return NotFound();
           
                _db.Remove(obj);
                _db.Save();
            TempData["success"] = "user delete successfully";
            return RedirectToAction("Index"); 
        }
    }
}

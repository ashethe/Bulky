using Bulky.DataAccess.Repository.IRepository;
using Bulky.DataAccess.Repository.Repository;
using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository category;
        public CategoryController(ICategoryRepository _category)
        {
            category = _category;
        }
        public IActionResult Index()
        {
            List<Category> categories = category.GetAll().ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display order cannot be same");
            }
            if (ModelState.IsValid) 
            {
                category.Add(obj);
                category.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            { 
                return NotFound(); 
            } 
            Category? categoryFind = category.Get(u => u.Id == id);
            return View(categoryFind);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display order cannot be same");
            }
            if (ModelState.IsValid)
            {
                category.Update(obj);
                category.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryFind = category.Get(u => u.Id == id);
            if (categoryFind == null)
            { return NotFound(); }
            category.Remove(categoryFind);
            category.Save();
            return RedirectToAction("Index", "Category");
        }
    }
}

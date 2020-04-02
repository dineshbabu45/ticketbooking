using AutoMapper;
using BusBooking.BL;
using BusBooking.Entity;
using OnlineTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicketBooking.Controllers
{
    public class CategoryController : Controller
    {

        public CategoryBL categoryBL;
        public CategoryController() //Constructor.
        {
            categoryBL = new CategoryBL(); //Creating object to access CategoryBL class.
        }

        public ActionResult Index() // GET Category
        {
            var categories = categoryBL.GetCategoryDetails(); //Method call to Category BL
            return View(categories);
        }

        public ActionResult AddCategory() //Add Category [GET]
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel categoryModel) //Add Category [POST]
        {
            if (ModelState.IsValid)
            {
                //Auto Mapper.
                var mapCategory = new MapperConfiguration(configExpression => { configExpression.CreateMap<CategoryViewModel, Category>(); });
                IMapper mapper = mapCategory.CreateMapper();
                var category = mapper.Map<CategoryViewModel, Category>(categoryModel);
                categoryBL.AddCategory(category); //Method call to add category
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            categoryBL.Delete(id);
            TempData["Message"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Category category=categoryBL.GetCategoryByID(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryViewModel>();
            });
            IMapper mapper = config.CreateMapper();
            var categories = mapper.Map<Category, CategoryViewModel>(category);
            return View(categories);
        }
        [HttpPost]
        public ActionResult Update(CategoryViewModel categoryViewModel)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap< CategoryViewModel,Category>();
            });
            IMapper mapper = config.CreateMapper();
            var category = mapper.Map<CategoryViewModel, Category>(categoryViewModel);

            categoryBL.Update(category);
            TempData["Message"] = "category Edited successfully!!";
            return RedirectToAction("Index");
        }
    }
}
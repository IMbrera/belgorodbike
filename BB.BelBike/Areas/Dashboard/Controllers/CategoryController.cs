using BB.BelBike.Areas.Dashboard.ViewModel;
using BB.Services;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BB.BelBike.Areas.Dashboard.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService categoryService = new CategoryService();
       
        public ActionResult Index(string search)
        {
            CategoryModel model = new CategoryModel();
            model.Search = search;
            model.Categories = categoryService.SearchCategory(search);
            return View(model);
        }
        public ActionResult List()
        {
            CategoryModel model = new CategoryModel();
            model.Categories = categoryService.GetCategories();
            return PartialView("_List", model);
        }
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            ActionCategoryModel model = new ActionCategoryModel();
            if (ID.HasValue)
            {
                var category = categoryService.GetCategoryID(ID.Value);
                model.ID = category.ID;
                model.Name = category.Name;
              
            }
            return PartialView("_Action", model);
        }
        [HttpPost]
        public JsonResult Action(ActionCategoryModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)
            {
                var category = categoryService.GetCategoryID(model.ID);
                category.Name = model.Name;
                result = categoryService.UpdateCategory(category);
            }
            else
            {
                Category category = new Category();
                category.Name = model.Name;
                
                result = categoryService.SaveCategory(category);
            }
            if (result)
            {
                json.Data = new { Success = true };
                TempData["message"] = string.Format("Изменения сохранены");
            }
            else
            {
                json.Data = new { Success = false, Message = "Ошибка" };
            }

            return json;
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            ActionCategoryModel model = new ActionCategoryModel();
            var category = categoryService.GetCategoryID(ID);
            model.ID = category.ID;
            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(ActionCategoryModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var category = categoryService.GetCategoryID(model.ID);

            result = categoryService.DeleteCategory(category);

            if (result)
            {
                json.Data = new { Success = true };
                TempData["message"] = string.Format("Запись \"{0}\" была удалена", category.Name);
            }
            else
            {
                json.Data = new { Success = false, Message = "Ошибка" };
            }

            return json;
        }
    }
}
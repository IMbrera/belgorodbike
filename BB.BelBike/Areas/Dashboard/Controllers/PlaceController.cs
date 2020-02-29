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
    public class PlaceController : Controller
    {
        PlaceService placeService = new PlaceService();
        public ActionResult Index(string search)
        {
            PlaceModel model = new PlaceModel();
            model.Search = search;
            model.Places = placeService.SearchPlaces(search);
            return View(model);
        }
        public ActionResult List()
        {
            PlaceModel model = new PlaceModel();
            model.Places = placeService.GetPlaces();
            return PartialView("_List", model);
        }
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            PlaceActionModel model = new PlaceActionModel();
            if (ID.HasValue)
            {
                var place = placeService.GetPlaceID(ID.Value);
                model.ID = place.ID;
                model.Name = place.Name;
                model.Coords = place.Coords;
            }
            return PartialView("_Action", model);
        }
        [HttpPost]
        public JsonResult Action(PlaceActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)
            {
                var place = placeService.GetPlaceID(model.ID);
                place.Name = model.Name;
                place.Coords = model.Coords;
                result = placeService.UpdatePlace(place);
            }
            else
            {
                Place place = new Place();
                place.Name = model.Name;
                place.Coords = model.Coords;
                result = placeService.SavePlace(place);
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
            PlaceActionModel model = new PlaceActionModel();
            var place = placeService.GetPlaceID(ID);
            model.ID = place.ID;
            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(PlaceActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var place = placeService.GetPlaceID(model.ID);

            result = placeService.DeletePlace(place);

            if (result)
            {
                json.Data = new { Success = true };
                TempData["message"] = string.Format("Запись \"{0}\" была удален", place.Name);
            }
            else
            {
                json.Data = new { Success = false, Message = "Ошибка" };
            }

            return json;
        }
    }
}
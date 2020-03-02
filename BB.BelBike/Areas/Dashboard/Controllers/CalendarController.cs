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
    public class CalendarController : Controller
    {
        PlaceService placeService = new PlaceService();
        CalendarService calendarService = new CalendarService();

        public ActionResult Index(string search, int? placeID, int? page) //int? PlaceID)
        {
            int recordSize = 10;
            page = page ?? 1;
            CalendarModel model = new CalendarModel();
            model.PlaceID = placeID;
            model.Search = search;
            model.Calendars = calendarService.SearchCalendar(search,placeID, page.Value, recordSize);
            model.Places = placeService.GetPlaces();
            var totalRecords = calendarService.SearchCalendarCount(search, placeID);
            model.Pager = new BelBike.ViewModel.Pager(totalRecords, page, recordSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Action(int? ID)
        {
            CalendarActionModel model = new CalendarActionModel();

            if (ID.HasValue) //we are trying to edit a record
            {
                var calendar = calendarService.GetCalendarID(ID.Value);
                model.ID = calendar.ID;
                model.PlaceID = calendar.PlaceID;
                model.Name = calendar.Name;
                model.DateOrg = calendar.DateOrg;
            }

            model.Places = placeService.GetPlaces();

            return PartialView("_Action", model);
        }

        [HttpPost]
        public JsonResult Action(CalendarActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)
            {
                var calendar = calendarService.GetCalendarID(model.ID);
                calendar.PlaceID = model.PlaceID;
                calendar.Name = model.Name;
                calendar.DateOrg = model.DateOrg;
                result = calendarService.UpdateCalendar(calendar);
            }
            else 
            {
                Calendar calendar = new Calendar();
                calendar.PlaceID = model.PlaceID;
                calendar.Name = model.Name;
                calendar.DateOrg = model.DateOrg;
                result = calendarService.SaveCalendar(calendar);
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
            CalendarActionModel model = new CalendarActionModel();
            var calendar = calendarService.GetCalendarID(ID);
            model.ID = calendar.ID;
            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(CalendarActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var calendar = calendarService.GetCalendarID(model.ID);

            result = calendarService.DeleteCalendar(calendar);

            if (result)
            {
                json.Data = new { Success = true };
                TempData["message"] = string.Format("Запись \"{0}\" была удалена", calendar.Name);
            }
            else
            {
                json.Data = new { Success = false, Message = "Ошибка" };
            }

            return json;
        }
    }
}
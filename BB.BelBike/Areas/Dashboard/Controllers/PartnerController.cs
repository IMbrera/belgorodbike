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
    public class PartnerController : Controller
    {
        PartnerServices partnerServices = new PartnerServices();
        // GET: Dashboard/Partner
        public ActionResult Index(string search)
        {
            PartnerModel model = new PartnerModel();
            model.Search = search;
            model.Partners = partnerServices.SearchPartners(search);
            return View(model);
        }
        public ActionResult List()
        {
            PartnerModel model = new PartnerModel();
            model.Partners = partnerServices.GetPartners();
            return PartialView("_List", model);
        }
        [HttpGet]
        public ActionResult Action(int? ID)
        {
            PartnerActionModel model = new PartnerActionModel();
            if (ID.HasValue)
            {
                var partner = partnerServices.GetPartnerID(ID.Value);
                model.ID = partner.ID;
                model.Name = partner.Name;
            }
            return PartialView("_Action", model);
        }
        [HttpPost]
        public JsonResult Action(PartnerActionModel model)
        {
            JsonResult json = new JsonResult();
            var result = false;
            if (model.ID > 0)
            {
                var partner = partnerServices.GetPartnerID(model.ID);
                 partner.Name = model.Name;
                result = partnerServices.UpdatePartner(partner);
            }
            else
            {
                Partner partner = new Partner();
                partner.Name = model.Name;
                result = partnerServices.SavePartner(partner);
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
            PartnerActionModel model = new PartnerActionModel();

            var partner = partnerServices.GetPartnerID(ID);

            model.ID = partner.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(PartnerActionModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var partner = partnerServices.GetPartnerID(model.ID);

            result = partnerServices.DeletePartner(partner);

            if (result)
            {
                json.Data = new { Success = true };
                TempData["message"] = string.Format("Партнер был удален");
            }
            else
            {
                json.Data = new { Success = false, Message = "Ошибка" };
            }

            return json;
        }
    }
}
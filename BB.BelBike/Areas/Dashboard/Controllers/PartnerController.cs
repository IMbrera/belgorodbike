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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            PartnerModel model = new PartnerModel();
            model.Partners = partnerServices.GetPartners();
            return PartialView("_List", model);
        }
        [HttpGet]
        public ActionResult Action()
        {
            PartnerActionModel model = new PartnerActionModel();

            return PartialView("_Action", model);
        }
        [HttpPost]
        public JsonResult Action(PartnerActionModel model)
        {
            JsonResult json = new JsonResult();

            Partner partner = new Partner();

            partner.Name = model.Name;


            var result = partnerServices.SavePartner(partner);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Ошибка" };
            }

            return json;
        }
    }
}
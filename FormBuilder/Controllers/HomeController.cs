using FormBuilder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace FormBuilder.Controllers
{
    public class HomeController : Controller
    {
        private DAL.FormContext db = new DAL.FormContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult CreateForm(CustomForm formData)
        {

            var ctx = Request.GetOwinContext();

            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

            // Get the claims values
            var userId = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                               .Select(c => c.Value).SingleOrDefault();

            CustomForm form = new CustomForm
            {
                Name = formData.Name,
                Description = formData.Description,
                CreatedAt = formData.CreatedAt,
                Fields = formData.Fields,
                UserId = int.Parse(userId),
            };

            db.Forms.Add(form);
            db.SaveChanges();

            return Json(form, JsonRequestBehavior.AllowGet);
        }

    }
}
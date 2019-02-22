using FormBuilder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace FormBuilder.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DAL.FormContext db = new DAL.FormContext();

        public ActionResult Index()
        {

            var ctx = Request.GetOwinContext();

            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

            // Get the claims values
            var userId = identity.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier)
                               .Select(c => c.Value).SingleOrDefault();

            int id = Convert.ToInt32(userId);

            return View(db.Forms.Where(i => i.UserId == id).ToList());
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult CreateForm(CustomForm formData)
        {

            var ctx = Request.GetOwinContext();

            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;

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

        // GET/showform/id
        public ActionResult ShowForm(int? id)
        {
            //ViewData["id"] = id;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomForm customForm = db.Forms.Find(id);

            if (customForm == null)
            {
                return HttpNotFound();
            }
            return View(customForm);
        }

    }
}
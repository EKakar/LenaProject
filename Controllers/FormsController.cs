using LenaProject.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LenaProject.Controllers
{
    public class FormsController : Controller
    {
        LenaFormDBEntities db = new LenaFormDBEntities();

        [Authorize]
        public ActionResult FormList(Users user)
        {
            var formsList = db.Forms.Where(x => x.UserId == user.UserId);
            return View(formsList);
        }

        [Authorize]
        public ActionResult FormCreate()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult FormCreate(Forms form)
        {
            var userId = Session["userId"];

            var user = db.Users.FirstOrDefault(x => x.UserId == (int)userId);

            form.CreatedAt = DateTime.Now;
            form.UserId = (int)userId;
            db.Forms.Add(form);
            db.SaveChanges();

            return RedirectToAction("FormList", user);
        }

        [Authorize]
        [HttpGet]
        [Route("{controller}/forms{id}")]
        public ActionResult FormDetails(int id)
        {
            var form = db.Forms.FirstOrDefault(x => x.FormId == id);
            return View("FormDetails", form);
        }

        [Authorize]
        public ActionResult FormEdit(int id)
        {
            var form = db.Forms.FirstOrDefault(x => x.FormId == id);

            return View(form);
        }

        [Authorize]
        [HttpPost]
        public ActionResult FormEdit(Forms form)
        {
            var frm = db.Forms.FirstOrDefault(x => x.FormId == form.FormId);
            var user = db.Users.FirstOrDefault(x => x.UserId == form.UserId);

            db.Forms.Remove(frm);
            db.Forms.Add(form);
            db.SaveChanges();

            return RedirectToAction("FormList", user);
        }
    }
}
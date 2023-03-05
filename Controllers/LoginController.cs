using LenaProject.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace LenaProject.Controllers
{

    public class LoginController : Controller
    {
        LenaFormDBEntities db = new LenaFormDBEntities();

        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Users user)
        {
            var userObj = db.Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);

            if (userObj != null)
            {
                Session["userId"] = userObj.UserId;
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("FormList", "Forms", userObj);
            }
            else
            {
                ViewBag.LoginError = "Hatalı Kullanıcı Adı veya Şifre";
                return View();
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
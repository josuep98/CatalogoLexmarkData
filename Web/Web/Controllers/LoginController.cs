using Business.Business;
using Business.IBusiness;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        IUserBusiness userBusiness = new UserBusiness();

        // GET: Login
        public ActionResult Index()
        {
            //
            if (Session["loginSession"] != null)
                Session["loginSession"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAuth user)
        {
            var login = userBusiness.Login(new Data.Data.User
            {
                User1 = user.UserName,
                Password = user.Password
            });

            if (login.Login)
            {
                Session["loginSession"] = login;
                return RedirectToAction("Index", "Category");
            }
            else
                return RedirectToAction("Index");
        }

    }
}
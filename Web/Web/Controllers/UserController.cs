using Business.Business;
using Business.IBusiness;
using Data.Data;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserBusiness userBusiness = new UserBusiness();
        private readonly IRolBusiness rolBusiness = new RolBusiness();
        // GET: User
        public ActionResult Index()
        {
            var users = userBusiness.GetAllActive();
            return View(users);
        }

        // GET: User/Create
        public ActionResult Create(int id = 0)
        {
            User user = userBusiness.GetById(id);
            var rolList = rolBusiness.GetAllActive();
            ViewBag.RolList = new SelectList(rolList, "Id", "Name");
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                if (user.Id > 0)
                {
                    user.Status = true;
                    user.CreationDate = System.DateTime.UtcNow;
                    userBusiness.Update(user);
                }
                else
                    userBusiness.Add(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var user = userBusiness.GetById(id);
                user.Status = false;
                userBusiness.Update(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}

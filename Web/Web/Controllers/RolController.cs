using Business.Business;
using Business.IBusiness;
using Data.Data;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class RolController : Controller
    {
        private readonly IRolBusiness rolBusiness = new RolBusiness();
        // GET: Rol
        public ActionResult Index()
        {
            var roles = rolBusiness.GetAllActive();
            return View(roles);
        }

        // GET: Rol/Create
        public ActionResult Create(int id = 0)
        {
            Rol rol = rolBusiness.GetById(id);
            return View(rol);
        }

        // POST: Rol/Create
        [HttpPost]
        public ActionResult Create(Rol rol)
        {
            try
            {
                if (rol.Id > 0)
                {
                    rol.Status = true;
                    rolBusiness.Update(rol);
                }
                else
                    rolBusiness.Add(rol);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rol/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var rol = rolBusiness.GetById(id);
                rol.Status = false;
                rolBusiness.Update(rol);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}

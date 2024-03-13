using Business.Business;
using Business.IBusiness;
using Data.Data;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryBusiness categoryBusiness = new CategoryBusiness();
        private IFileBusiness fileBusiness = new FileBusiness();
        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryBusiness.GetAllActive();
            return View(categories);
        }

        // GET: Category/Create
        public ActionResult Create(int id = 0)
        {
            Category category = categoryBusiness.GetById(id);
            return View(category);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category, HttpPostedFileBase PostedFile)
        {
            try
            {
                string imageName = fileBusiness.UploadFile(PostedFile);
                category.Image = imageName;
                if (category.Id > 0)
                {
                    category.Status = true;
                    categoryBusiness.Update(category);
                }
                else
                    categoryBusiness.Add(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var category = categoryBusiness.GetById(id);
                category.Status = false;
                categoryBusiness.Update(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

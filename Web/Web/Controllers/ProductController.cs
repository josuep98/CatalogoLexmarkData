using Business.Business;
using Business.IBusiness;
using Data.Data;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBusiness productBusiness = new ProductBusiness();
        private readonly ICategoryBusiness categoryBusiness = new CategoryBusiness();
        private readonly IUserBusiness userBusiness = new UserBusiness();
        private IFileBusiness fileBusiness = new FileBusiness();

        // GET: Product
        public ActionResult Index()
        {
            var products = productBusiness.GetAllActive();
            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create(int id = 0)
        {
            Product product = productBusiness.GetById(id);
            var categoryList = categoryBusiness.GetAllActive();
            ViewBag.CategoryList = new SelectList(categoryList, "Id", "Name");

            var userList = userBusiness.GetAllActive();
            ViewBag.UserList = new SelectList(userList, "Id", "User1");
            return View(product);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase PostedFile)
        {
            try
            {
                string imageName = fileBusiness.UploadFile(PostedFile);
                product.Image = imageName;
                if (product.Id > 0)
                {
                    product.Status = true;
                    productBusiness.Update(product);
                }
                else
                    productBusiness.Add(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var product = productBusiness.GetById(id);
                product.Status = false;
                productBusiness.Update(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}

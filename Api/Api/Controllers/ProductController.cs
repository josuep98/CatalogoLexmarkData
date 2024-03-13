using Business.Business;
using Business.IBusiness;
using System;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductBusiness productBusiness;

        public ProductController()
        {
            productBusiness = new ProductBusiness();
        }

        [HttpGet]
        [Route("api/product/{id}")]
        public IHttpActionResult GetCategories(int id = 0)
        {
            try
            {
                var product = productBusiness.GetListById(id);
                if (product.Count() > 0)
                    return Ok(product);
                else
                    return BadRequest("No se encontró data!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
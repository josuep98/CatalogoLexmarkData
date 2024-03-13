using Business.Business;
using Business.IBusiness;
using System;
using System.Linq;
using System.Web.Http;

namespace Api.Api
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryBusiness categoryBusiness;

        public CategoryController()
        {
            categoryBusiness = new CategoryBusiness();
        }

        [HttpGet]
        [Route("api/category")]
        public IHttpActionResult GetCategories()
        {
            try
            {
                var categories = categoryBusiness.GetAllRequest();
                if (categories.Count() > 0)
                    return Ok(categories);
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
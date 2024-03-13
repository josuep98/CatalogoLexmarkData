using Business.IBusiness;
using Business.Models.Response;
using Data.Data;
using Data.IRepository;
using Data.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Business.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository productRepository;
        public ProductBusiness()
        {
            productRepository = new ProductRepository();
        }

        public void Add(Product entity)
        {
            entity.Status = true;
            productRepository.Add(entity);
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        public List<Product> GetAllActive()
        {
            using (var context = new LexmarkCatalogEntities())
            {
                return context.Product.Where(x => (bool)x.Status)
                                      .Include(x => x.Category)
                                      .ToList();
            }
        }

        public Product GetById(int id)
        {
            return productRepository.GetById(id);
        }

        public List<ProductResponse> GetListById(int id)
        {
            List<ProductResponse> result = new List<ProductResponse>();
            if (id > 0)
            {
                result = productRepository.GetAll().Where(x => x.CategoryId == id)
                                                             .Where(x => (bool)x.Status)
                                                             .Select(r => new ProductResponse
                                                             {
                                                                 Id = r.Id,
                                                                 Image = r.Image,
                                                                 Model = r.Model,
                                                                 NumberPart = r.NumberPart,
                                                                 PrintSpeed = r.PrintSpeed ?? 0,
                                                                 MaxMonthly = r.MaxMonthly ?? 0,
                                                                 RecMonthly = r.RecMonthly ?? 0,
                                                                 Detail = r.Detail ?? "-",
                                                                 Pvp = r.Pvp ?? 0,
                                                                 CategoryId = r.CategoryId,
                                                             }).ToList();
            }
            else
            {
                result = productRepository.GetAll().Where(x => (bool)x.Status)
                                                   .Select(r => new ProductResponse
                                                   {
                                                       Id = r.Id,
                                                       Image = r.Image,
                                                       Model = r.Model,
                                                       NumberPart = r.NumberPart,
                                                       PrintSpeed = r.PrintSpeed,
                                                       MaxMonthly = r.MaxMonthly,
                                                       RecMonthly = r.RecMonthly,
                                                       Detail = r.Detail,
                                                       Pvp = r.Pvp,
                                                       CategoryId = r.CategoryId,
                                                   }).ToList();
            }

            return result;
        }

        public void Update(Product entity)
        {
            productRepository.Update(entity);
        }
    }
}

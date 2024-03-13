using Business.Models.Response;
using Data.Data;
using Data.IRepository;
using System.Collections.Generic;

namespace Business.IBusiness
{
    public interface IProductBusiness : IProductRepository
    {
        List<Product> GetAllActive();
        List<ProductResponse> GetListById(int id);
    }
}

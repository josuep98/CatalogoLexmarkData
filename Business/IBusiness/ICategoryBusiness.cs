using Business.Models.Request;
using Data.Data;
using Data.IRepository;
using System.Collections.Generic;

namespace Business.IBusiness
{
    public interface ICategoryBusiness : ICategoryRepository
    {
        List<CategoryResponse> GetAllRequest();
        List<Category> GetAllActive();
    }
}

using Business.IBusiness;
using Business.Models.Request;
using Data.Data;
using Data.IRepository;
using Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business.Business
{
    public class CategoryBusiness : ICategoryBusiness
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryBusiness()
        {
            categoryRepository = new CategoryRepository();
        }

        public void Add(Category entity)
        {
            entity.Status = true;
            categoryRepository.Add(entity);
        }

        public void Delete(int id)
        {
            categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public List<Category> GetAllActive()
        {
            return categoryRepository.GetAll().Where(x => (bool)x.Status).ToList();
        }

        public List<CategoryResponse> GetAllRequest()
        {
            var response = categoryRepository.GetAll().Where(x => (bool)x.Status).Select(s => new CategoryResponse
            {
                Id = s.Id,
                Name = s.Name,
                Image = s.Image
            }).ToList();

            return response;
        }

        public Category GetById(int id)
        {
            return categoryRepository.GetById(id);
        }

        public void Update(Category entity)
        {
            categoryRepository.Update(entity);
        }
    }
}

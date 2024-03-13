using Business.IBusiness;
using Data.Data;
using Data.IRepository;
using Data.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business.Business
{
    public class RolBusiness : IRolBusiness
    {
        private readonly IRolRepository rolRepository;
        public RolBusiness()
        {
            rolRepository = new RolRepository();
        }

        public void Add(Rol entity)
        {
            entity.Status = true;
            rolRepository.Add(entity);
        }

        public void Delete(int id)
        {
            rolRepository.Delete(id);
        }

        public IEnumerable<Rol> GetAll()
        {
            return rolRepository.GetAll();
        }

        public List<Rol> GetAllActive()
        {
            return rolRepository.GetAll().Where(x => (bool)x.Status).ToList();
        }

        public Rol GetById(int id)
        {
            return rolRepository.GetById(id);
        }

        public void Update(Rol entity)
        {
            rolRepository.Update(entity);
        }
    }
}

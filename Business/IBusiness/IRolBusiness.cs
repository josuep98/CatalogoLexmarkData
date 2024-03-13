using Data.Data;
using Data.IRepository;
using System.Collections.Generic;

namespace Business.IBusiness
{
    public interface IRolBusiness : IRolRepository
    {
        List<Rol> GetAllActive();
    }
}

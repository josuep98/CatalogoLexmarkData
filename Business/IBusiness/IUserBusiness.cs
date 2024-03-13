using Business.Models.Response;
using Data.Data;
using Data.IRepository;
using System.Collections.Generic;

namespace Business.IBusiness
{
    public interface IUserBusiness : IUserRepository
    {
        List<User> GetAllActive();

        UserAuthResponse Login(User user);
    }
}

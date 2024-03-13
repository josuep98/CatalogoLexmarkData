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
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository userRepository;
        public UserBusiness()
        {
            userRepository = new UserRepository();
        }

        public void Add(User entity)
        {
            entity.Status = true;
            entity.CreationDate = System.DateTime.UtcNow;
            userRepository.Add(entity);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public List<User> GetAllActive()
        {
            using (var context = new LexmarkCatalogEntities())
            {
                return context.User.Where(x => (bool)x.Status)
                                   .Include(x => x.Rol)
                                   .ToList();
            }
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public void Update(User entity)
        {
            userRepository.Update(entity);
        }

        public UserAuthResponse Login(User user)
        {
            var userAuth = userRepository.GetAll().Where(u => u.User1 == user.User1 && u.Password == user.Password).FirstOrDefault();
            if (userAuth != null)
            {
                return new UserAuthResponse
                {
                    UserName = userAuth.User1,
                    Name = userAuth.FirstName + " " + userAuth.FirstLastName,
                    UserId = userAuth.Id,
                    Login = true
                };
            }
            else
                return new UserAuthResponse { Login = false };
        }

    }
}

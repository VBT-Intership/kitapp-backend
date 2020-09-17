using Dal.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete.EntityFramework.Repository
{
    public class EfUserRepository : EfGenericRepository<Users>, IUserRepository
    {
        public EfUserRepository():base()
        {
            
        }

        public Users Login(string email, string password)
        {
            return context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public Users RegisterUser(Users user)
        {
            user.IsActive = true;
            user.IDate = DateTime.Now;
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}

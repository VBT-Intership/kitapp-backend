using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Abstract
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        Users Login(string email, string password);
        Users RegisterUser(Users user);


    }
}

using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserService : IGenericService<Users>
    {

        Users Login(string email, string password);
        Users RegisterUser(Users user);

    }
}

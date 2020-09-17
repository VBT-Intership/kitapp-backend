using Dal.Abstract;
using Dal.AbstractInterfaces;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Bll
{
    public class UserManager : GenericManager<Users>, IUserService
    {
        IUserRepository userRepository;

        public UserManager(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

        public Users Login(string email, string password)
        {
            return userRepository.Login(email, password);
        }

        public Users RegisterUser(Users user)
        {
            return userRepository.RegisterUser(user);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Concrete.EntityFramework.Context;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FlutterApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserService userContext;
        public UserController(IUserService user)
        {
            this.userContext = user;
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var product = userContext.Login(username, password);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            var product = userContext.RegisterUser(user);
            return Ok(product);
        }

    }
}
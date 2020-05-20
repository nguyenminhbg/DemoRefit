using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoRefitController : ControllerBase
    {
        [HttpGet("users/{user}")]
        public Task<User> GetUser(string user)
        {
            var userInstance = new User() { FullName = "Nguyen Van Minh", UserName = "MinhNguyen" };
            return Task.FromResult(userInstance);
        }
        [HttpGet("users/list")]
        public Task<List<User>> GetUserList()
        {
            var listUser = new List<User>();
            for (var i = 0; i <= 9; ++i)
            {
                listUser.Add(new User() { FullName = "Nguyen Van Minh", UserName = "MinhNguyen" });
            }
            return Task.FromResult(listUser);
        }
    }
}
using DemoLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Demo.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoRefitController : ControllerBase
    {
        public DemoRefitController(IStorageService storageService)
        {
            _storageService = storageService;
        }
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
        [HttpGet("group/{id}/users")]
        public Task<List<User>> GetListAlias(int id)
        {
            var listUser = new List<User>();
            for (var i = 0; i <= 9; ++i)
            {
                listUser.Add(new User() { FullName = "Do Thanh Binh", UserName = "ThanhBinh" });
            }
            return Task.FromResult(listUser);
        }
        [HttpGet("group/{id}/users/{userid}")]
        public Task<List<User>> GroupRequest(int id, int userid)
        {
            var listUser = new List<User>();
            for (var i = 0; i <= 9; ++i)
            {
                listUser.Add(new User() { FullName = "Do Thanh Binh", UserName = "ThanhBinh" });
            }
            return Task.FromResult(listUser);
        }
        [HttpGet("search/admin/products")]
        public Task<string> Search()
        {
            return Task.FromResult("Admin Do Thanh Hai");
        }
        [HttpPost("users/new/account")]
        public Task<IActionResult> CreateUser([FromBody] User username)
        {
            return Task.FromResult<IActionResult>(Ok(username.UserName));
        }
        [HttpPost("images")]
        public async Task<IActionResult> CreateImage([FromForm]ImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string path = "";
            // Kiểm tra file
            if (request.ImageFile != null)
            {
                path = await SaveFile(request.ImageFile);// trả về đường dẫn
            }
            else path = "Không Upload được ảnh";
            return Ok(path);
        }
        [HttpPost("users/new/account/endcode")]
        [Consumes("application/x-www-form-urlencoded")]
        public Task<IActionResult> CreateUserEndcode([FromForm]Dictionary<string, string> data)
        {
            return Task.FromResult<IActionResult>(Ok(data.Values));
        }
       
        private readonly IStorageService _storageService;
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
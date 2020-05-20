using DemoLibrary;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole
{
    public interface IGitHubApi
    {
        [Get("/api/Test/TestRefit/users/{user}")]
        Task<User> GetUser(string user);

        [Get("/api/Test/TestRefit/users/list")]
        Task<List<User>> GetUserList();
    }
}

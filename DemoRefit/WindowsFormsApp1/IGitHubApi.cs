using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IGitHubApi
    {
        [Get("/api/demorefit/users/{user}")]
        Task<User> GetUser(string user);

        [Get("/api/demorefit/users/list")]
        Task<List<User>> GetUserList();
    }
}

using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace WindowsFormsApp1
{
    public interface IGitHubApi
    {
        [Get("/api/demorefit/users/{user}")]
        Task<User> GetUser(string user);

        [Get("/api/demorefit/users/list")]
        Task<List<User>> GetUserList();
        [Get("/api/demorefit/group/{id}/users")]
        Task<List<User>> GroupList([AliasAs("id")] int groupId);
        [Get("/api/demorefit/group/{request.groupId}/users/{request.userId}")]
        Task<List<User>> GroupListBlock(UserGroupRequest request);
        [Get("/api/demorefit/search/{**page}")]
        Task<string> Search(string page);
        [Post("/api/demorefit/users/new/account")]
        Task<string> CreateUser([Body]User  username);
        [Post("/api/demorefit/users/new/account/endcode")]
        Task<string> CreateUserEndcode([Body(BodySerializationMethod.UrlEncoded)]Dictionary<string,string> data);
    }
}

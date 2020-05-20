using DemoLibrary;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData();
            Console.ReadKey();
        }
        public async static void GetData()
        {

            //var result =await http.GetAsync("https://localhost:5001/api/DomoRefit/users/minh");
            //var responseContent = await result.Content.ReadAsStringAsync();
            while (!Help.instance.checkInit)
            {

            }
            Thread.Sleep(2000);
             await GetUser();
            //await GetUserList();
            // var request = new QueryUser() { sort = "desc" };
            //  await GetUserListQuery(request);
        }
        public async static Task<User> GetUser()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://localhost:5001");
            var user = await gitHubApi.GetUser("octocat");
            Console.WriteLine(user.FullName);
            return user;
        }
        public async static Task<List<User>> GetUserList()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://localhost:5001");
            var users = await gitHubApi.GetUserList();
            foreach (var item in users)
                Console.WriteLine(item.FullName);
            return users;
        }
    }
}

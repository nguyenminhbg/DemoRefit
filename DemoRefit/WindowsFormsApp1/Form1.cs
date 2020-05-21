using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static HttpClient http = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetUser();
        }
        public async void GetUser()
        {
            var result = await http.GetAsync("https://localhost:5001/api/demorefit/users/minh");
            var responseContent = await result.Content.ReadAsStringAsync();

            var gitHubApi = RestService.For<IGitHubApi>("https://localhost:5001");
            var user = await gitHubApi.GetUser("minh");
            showdata.Text = user.FullName;
        }
        public async void GetUserList()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://localhost:5001");
            var users = await gitHubApi.GetUserList();
            foreach (var item in users)
                showdata.Text += item.FullName;
        }

        public async void GroupList()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://localhost:5001");
            var users = await gitHubApi.GroupList(1);
            foreach (var item in users)
                showdata.Text += item.FullName;
        }
        public async void BlockRequest()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://localhost:5001");
            var userRequest = new UserGroupRequest() { groupId = 1, userId = 2 };
            var users = await gitHubApi.GroupListBlock(userRequest);
            foreach (var item in users)
                showdata.Text += item.FullName;
        }
        public async void Search()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://localhost:5001");
            var endpoint = "admin/products";
            var search = await gitHubApi.Search(endpoint);
            showdata.Text += search;
        }
        public async void CreateAccount()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://localhost:5001");
            var username =new User() { UserName = "minhedutalk", FullName="nguyen van minh"};
            var name = await gitHubApi.CreateUser(username);
           showdata.Text += name;
            //JObject @param = new JObject()
            //{
            //    new JProperty("UserName",username.UserName),
            //    new JProperty("FullName",username.FullName),
            //};
            //var content = JsonConvert.SerializeObject(param);
            //HttpContent httpContent = new StringContent(content,Encoding.UTF8, "application/json");
            //var result = await http.PostAsync("https://localhost:5001/api/demorefit/users/new/account", httpContent);
            //var responseContent = await result.Content.ReadAsStringAsync();
            //showdata.Text += responseContent;
        }
        public async void CreateUserEndcode()
        {
            var gitHubApi = RestService.For<IGitHubApi>("https://localhost:5001");
            var username = new User() { UserName = "minhedutalk", FullName = "nguyen van minh" };
            var dic = new Dictionary<string, string>();
            dic.Add("hoten", "Nguyen Van Minh");
            var name = await gitHubApi.CreateUserEndcode(dic);
            showdata.Text += name;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            GetUserList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GroupList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BlockRequest();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CreateAccount();
        }

        private async void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CreateUserEndcode();
        }
    }
}

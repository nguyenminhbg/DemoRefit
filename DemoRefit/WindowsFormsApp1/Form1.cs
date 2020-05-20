using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        private void button3_Click(object sender, EventArgs e)
        {
            GetUserList();
        }
    }
}

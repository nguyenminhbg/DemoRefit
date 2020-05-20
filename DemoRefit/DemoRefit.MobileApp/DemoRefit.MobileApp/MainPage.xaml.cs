using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoRefit.MobileApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public static HttpClient http = new HttpClient() { Timeout = TimeSpan.FromSeconds(60) };
        private async void Button_Clicked(object sender, EventArgs e)
        {
            GetUser();
        }
        public async void GetUser()
        {
            var result = await http.GetAsync("http:edutalk.com/api/demorefit/users/minh");
            var responseContent = await result.Content.ReadAsStringAsync();
            // var gitHubApi = RestService.For<IGitHubApi>("http://10.0.2.2:5001");
            //  var user = await gitHubApi.GetUser("octocat");
            // Console.WriteLine(user.FullName);
            //return user;
        }
    }
}

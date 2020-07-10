using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Covid19.Views.Forms;
using Covid19.Views.Profile;
using Covid19.Views.Navigation;
using Covid19.Views.Dashboard;

namespace Covid19
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRGiVU5AazUo9Op4o_-hd-hCsPuTkO7VZN361mYnqhsXYALIi3-&usqp=CAU";
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            MainPage = new NavigationPage(new SimpleLoginPage());  
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

using Covid19.Models;
using Covid19.Views.Dashboard;
using Covid19.Views.Navigation;
using Newtonsoft.Json;
using System;

using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Covid19.Views.Forms
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleLoginPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleLoginPage" /> class.
        /// </summary>
        public SimpleLoginPage()
        {
            InitializeComponent();
        }
        private async void ForgotPassword(object sender,EventArgs args)
        {
            await Navigation.PushAsync(new Covid19.Views.ForgotPassword.SimpleForgotPasswordPage());
        }

        protected async void OnSignupCliked(object sender,EventArgs args)
        {
            await Navigation.PushAsync(new SimpleSignUpPage());
        }
        private void LoginProcess(object sender, EventArgs args)
        {
            ConstantsData data = new ConstantsData();
            var UserName = UserNameEntry.Text;
            var Password = PasswordEntry.Text;
            if (UserName.Equals(" ") && Password.Equals(" "))
            {
                DisplayAlert("Login", "UserName or Password is Empty", "ok");
                return;
            }
            else
            {
                var service = new Service12();
                Uri u = new Uri("http://192.168.43.215/api/New/AuthenticateUser");
                var payload = new Dictionary<string, string>
                {
                    {"UserName",UserName },
                    {"Password",Password }

                };
                string strpayload = JsonConvert.SerializeObject(payload);
                HttpContent c = new StringContent(strpayload, Encoding.UTF8, "application/json");
                var task = Task.Run(() => service.LoginProcess(u, c));
                task.Wait();
                if (task.Result != null)
                {
                    var status = task.Result[0].Status;
                    var Name = task.Result[0].Name;
                    var SlotId = task.Result[0].SlotId;
                    var IsSystem = task.Result[0].IsSystem;
                    if (status == "1")
                    {
                        //DisplayAlert("Login", "Success", "Ok");
                        UserNameEntry.Text = "";
                        PasswordEntry.Text = "";

                    }
                    if (status == "2")
                    {
                        DisplayAlert("Login", "Invalid UserName", "OK");
                        UserNameEntry.Text = "";
                        PasswordEntry.Text = "";
                        return;
                    }
                    if(status == "3")
                    {
                        DisplayAlert("Login", "Invalid Password", "OK");
                        UserNameEntry.Text = "";
                        PasswordEntry.Text = "";
                        return;
                    }
                    Application.Current.Properties["SlotId"] = SlotId;
                    if (IsSystem == 1)
                    { 
                        Navigation.PushAsync(new HealthCarePage());
                    }
                    else
                    {
                        Navigation.PushAsync(new LocationTrace());
                    }

                }
            }
        }

    }
}
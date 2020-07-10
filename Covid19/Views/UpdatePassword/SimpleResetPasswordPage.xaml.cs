using System;
using System.Text;
using Xamarin.Forms;
using Covid19.Models;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms.Xaml;
using Covid19.Views.Forms;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using System.Collections.Generic;

namespace Covid19.Views.UpdatePassword
{
    /// <summary>
    /// Page to reset old password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleResetPasswordPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleResetPasswordPage" /> class.
        /// </summary>
        public SimpleResetPasswordPage()
        {
            InitializeComponent();
            
        }
        private void UpdatePassword(object sender,EventArgs args)
        {
            var ChangePassword = NewPasswordEntry.Text;
            var confirmPassword = ConfirmNewPasswordEntry.Text;
            bool result = ChangePassword.Equals(confirmPassword);
            if (!result)
            {
                DisplayAlert("ForgotPassword", "Password Doesn't Match", "OK");
                return;
            }
            var PersonId = Application.Current.Properties["PersonId"].ToString();
            var Service = new Service12();
            Uri u = new Uri("http://192.168.43.215/api/New/UpdatePassword");
            var payload = new Dictionary<string, string>
            {
                {"PersonId",PersonId },
                {"ChangePassword",ChangePassword }
            };
            string strpayload = JsonConvert.SerializeObject(payload);
            HttpContent c = new StringContent(strpayload, Encoding.UTF8, "application/json");
            var task = Task.Run(() => Service.DataUpdate(u, c));
            task.Wait();
            if (task.Result == true)
            {
                NewPasswordEntry.Text = "";
                ConfirmNewPasswordEntry.Text = "";
                Navigation.PushAsync(new SimpleLoginPage());
            }
            else
            {
                DisplayAlert("ForgotPassword", "Something went Wrong", "OK");
                return;
            }
        }
    }
}
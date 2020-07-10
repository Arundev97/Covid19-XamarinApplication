using Covid19.Models;
using Covid19.Views.Dashboard;
using Covid19.Views.Forms;
using Covid19.Views.UpdatePassword;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Covid19.Views.ForgotPassword
{
    /// <summary>
    /// Page to retrieve the password forgotten.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleForgotPasswordPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleForgotPasswordPage" /> class.
        /// </summary>
        public SimpleForgotPasswordPage()
        {
            InitializeComponent();
        }
        private void PasswordProcess(object sender, EventArgs args)
        {
            ConstantsData data = new ConstantsData();
            var EmailId = EmailsEntry.Text;

            var service = new Service12();
            Uri u = new Uri("http://192.168.43.215/api/New/ForgotPassword");
            var payload = new Dictionary<string, string>
                {
                    {"Email",EmailId }

                };
            string strpayload = JsonConvert.SerializeObject(payload);
            HttpContent c = new StringContent(strpayload, Encoding.UTF8, "application/json");
            var task = Task.Run(() => service.ForgotPassword(u, c));
            task.Wait();
            if (task.Result != null)
            {
                var status = task.Result[0].Status;
                var Name = task.Result[0].Name;
                var PersonId = task.Result[0].PersonId;
                var Email = task.Result[0].Email;
                Application.Current.Properties["PersonId"] = PersonId;

                if (status == "1")
                {
                    Navigation.PushAsync(new SimpleResetPasswordPage());
                }
                else
                {
                    DisplayAlert("ForgotPassword", "Invalid Email", "OK");
                    EmailsEntry.Text = "";
                    return;
                }
            }
        }
    }
}
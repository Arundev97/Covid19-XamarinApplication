using Covid19.Models;
using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Covid19.Views.Forms
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleSignUpPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleSignUpPage" /> class.
        /// </summary>
        public SimpleSignUpPage()
        {
            InitializeComponent();
        }
        protected async void OnLoginClick(object sender,EventArgs args)
        {
            await Navigation.PushAsync(new SimpleLoginPage());
        }
        private void RegisterProcess(object sender, EventArgs args)
        {
            ConstantsData data = new ConstantsData();
            data.Name = NameEntry.Text;
            data.Age = AgeEntry.Text;
            data.Gender = GenderEntry.Text;
            data.MartialStatus = MartialEntry.Text;
            data.Occupation = OccupationEntry.Text;
            data.NoOfChildrens = ChildEntry.Text;
            data.Education = EducationEntry.Text;
            data.LivingStatus = StatusEntry.Text;
            data.Nationality = NationalityEntry.Text;
            data.UserName = UserNameEntry.Text;
            data.Password = PasswordEntry.Text;
            data.MobileNumber = MobileEntry.Text;
            data.Address = AddressEntry.Text;
            data.BloodGroup = BloodEntry.Text;
            data.FatherName = FatherEntry.Text;
            data.DateofBirth = DobEntry.Text;
            data.Email = EmailsEntry.Text;

            var service = new Service12();
            Uri u = new Uri("http://192.168.43.215/api/new/UserData");
            var payload = new Dictionary<string, object>
            {
                {"Name",data.Name },
                {"Age",data.Age },
                {"Gender",data.Gender },
                {"MartialStatus",data.MartialStatus },
                {"Occupation",data.Occupation },
                {"NoOfChildrens",data.NoOfChildrens },
                { "Education",data.Education },
                {"LivingStatus",data.LivingStatus },
                {"Nationality",data.Nationality },
                {"UserName",data.UserName },
                {"Password",data.Password },
                {"Address",data.Address },
                {"BloodGroup",data.BloodGroup },
                {"FatherName",data.FatherName },
                {"DateofBirth",data.DateofBirth },
                {"MobileNumber",data.MobileNumber },
                {"Email",data.Email },
                {"IsSystem",0}
            };
            string strpayload = JsonConvert.SerializeObject(payload);
            HttpContent c = new StringContent(strpayload, Encoding.UTF8, "application/json");
            var task = Task.Run(() => service.DataUpdate(u, c));
            task.Wait();
            if (task.Result == true)
            {
                DisplayAlert("Register", "DataSavedSucessfully", "OK");
                NameEntry.Text = "";
                AgeEntry.Text = "";
                GenderEntry.Text = "";
                MartialEntry.Text = "";
                EducationEntry.Text = "";
                OccupationEntry.Text = "";
                ChildEntry.Text = "";
                EmailsEntry.Text = "";
                MobileEntry.Text = "";
                StatusEntry.Text = "";
                UserNameEntry.Text = "";
                ConfirmPasswordEntry.Text = "";
                AddressEntry.Text = "";
                BloodEntry.Text = "";
                DobEntry.Text = "";
                UserNameEntry.Text = "";
                Navigation.PushAsync(new SimpleLoginPage());
            }
        }
    }
}
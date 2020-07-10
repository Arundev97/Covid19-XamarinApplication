using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Covid19.Views.Dashboard
{
    /// <summary>
    /// Page to show the health care details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HealthCarePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCarePage" /> class.
        /// </summary>
        public HealthCarePage()
        {
            InitializeComponent();
        }
        private async void OnItemSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs args)
        {
            var mydata = args.ItemData as Models.Dashboard.HealthCare;
            if(mydata.Category== "QuarantineCases")
            {
                await Navigation.PushAsync(new Covid19.Views.Navigation.NavigationListCardPage());
            }
            else if (mydata.Category == "CaseTimeReport")
            {
                await Navigation.PushAsync(new Covid19.Views.CaseDetails.MyAddressPage());
            }
            else if (mydata.Category == "State Wise")
            {
                await Navigation.PushAsync(new Covid19.Views.Statewise.MyAddressPage());
            }
            else if(mydata.Category == "OverAll Tested")
            {

            }
            else
            {
                return;
            }
           
        }
    }
}

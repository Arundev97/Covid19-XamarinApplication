using Covid19.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Covid19.ViewModels;
using Syncfusion.ListView.XForms;

namespace Covid19.Views.Navigation
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationListCardPage
    {
        public NavigationListCardPage()
        {
            InitializeComponent();
            // this.BindingContext = NavigationDataService.Instance.NavigationViewModel;
           
            var data = new ViewModels.Navigation.NavigationViewModel();
            listview.ItemsSource = data.DisplayData();
            listview.SelectionMode = Syncfusion.ListView.XForms.SelectionMode.Single;
            listview.SelectionGesture = TouchGesture.Tap;
            listview.SelectionBackgroundColor = Color.FromHex("#E4E4E4");

        }
        private async void OnItemSelected(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs args)
        {
            var mydata = args.ItemData as Models.Navigation.NavigationModel;
            await Navigation.PushAsync(new Views.Profile.ContactProfilePage(mydata.SlotID));
        }
    }
}
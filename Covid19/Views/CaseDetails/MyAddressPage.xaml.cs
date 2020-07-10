using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.Graphics;

namespace Covid19.Views.CaseDetails
{
    /// <summary>
    /// Page to show my address page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAddressPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyAddressPage" /> class.
        /// </summary>
        public MyAddressPage()
        {
            InitializeComponent();
            var data = new ViewModels.CaseDetails.MyAddressViewModel();
            myAddress.ItemsSource = data.DisplayData();
            
            myAddress.SelectionMode = Syncfusion.ListView.XForms.SelectionMode.Single;
            myAddress.SelectionGesture = Syncfusion.ListView.XForms.TouchGesture.Tap;
            myAddress.SelectionBackgroundColor = Color.FromHex("#E4E4E4");
        }
    }
}
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Covid19.Views.Statewise
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
            var datasource = new Covid19.ViewModels.Statewise.MyAddressViewModel();
            myAddress.ItemsSource = datasource.DisplayData();
        }
    }
}
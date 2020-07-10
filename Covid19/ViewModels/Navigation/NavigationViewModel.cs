using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using NavigationModel = Covid19.Models.Navigation.NavigationModel;

namespace Covid19.ViewModels.Navigation
{
    /// <summary>
    /// ViewModel for the Navigation list with cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class NavigationViewModel
    {
        #region Fields

        private Command<object> itemTappedCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="NavigationViewModel"/> class.
        /// </summary>
        public NavigationViewModel()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the command that will be executed when an item is selected.
        /// </summary>
        public Command<object> ItemTappedCommand
        {
            get
            {
                return this.itemTappedCommand ?? (this.itemTappedCommand = new Command<object>(this.NavigateToNextPage));
            }
        }

        /// <summary>
        /// Gets or sets a collection of values to be displayed in the Navigation list page.
        /// </summary>
        [DataMember]
        public ObservableCollection<NavigationModel> NavigationList { get; set; }

        public ObservableCollection<NavigationModel> DisplayData()
        {
            try
            {
                var t = Task.Run(() => GetData(new Uri("http://192.168.43.215/api/New/GetUserData")));
                t.Wait();
                if (t.Result != null)
                {
                    var status = t.Result;
                }
                ObservableCollection<NavigationModel> data = JsonConvert.DeserializeObject<ObservableCollection<NavigationModel>>(t.Result);

                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        private static async Task<string> GetData(Uri u)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage responseMessage = await client.GetAsync(u);
                if (responseMessage.IsSuccessStatusCode)
                {
                    response = await responseMessage.Content.ReadAsStringAsync();
                }
            }
            return response;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected from the navigation list.
        /// </summary>
        /// <param name="selectedItem">Selected item from the list view.</param>
        private void NavigateToNextPage(object selectedItem)
        {
            // Do something

        }
        private void Navigate(object selectitem, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {


        }
        #endregion
    }
}
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Covid19.Models;
using Covid19.Models.Dashboard;
using Newtonsoft.Json;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Covid19.ViewModels.Dashboard
{
    /// <summary>
    /// ViewModel for stock overview page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class HealthCareViewModel : BaseViewModel
    {
        #region Field

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<HealthCare> cardItems;

        /// <summary>
        /// To store the health care data collection.
        /// </summary>
        private ObservableCollection<HealthCare> listItems;

        /// <summary>
        /// To store the heart rate data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> heartRateData;

        /// <summary>
        /// To store the calories burned data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> caloriesBurnedData;

        /// <summary>
        /// To store the sleep time data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> sleepTimeData;

        /// <summary>
        /// To store the water consumed data collection.
        /// </summary>
        private ObservableCollection<ChartDataPoint> waterConsumedData;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="HealthCareViewModel" /> class.
        /// </summary>
        public HealthCareViewModel()
        {
            GetChartData();
            var service = new Service12();
            var t = Task.Run(() => service.GetResponse(new Uri("https://www.trackcorona.live/api/countries/IN")));
            t.Wait();
            if (t.Result != null)
            {
                var status = t.Result;
            }
            TrackData trackdata = JsonConvert.DeserializeObject<TrackData>(t.Result);
            cardItems = new ObservableCollection<HealthCare>()
            {
                 new HealthCare()
                 {
                    Category = "Location",
                    CategoryValue = trackdata.data[0].location,                    
                    BackgroundGradientStart = "#255ea6",
                    BackgroundGradientEnd = "#b350d1"
                 },
                new HealthCare()
                {
                    Category = "Confirmed",
                    CategoryValue = trackdata.data[0].confirmed,
                    ChartData = heartRateData,
                    BackgroundGradientStart = "#f59083",
                    BackgroundGradientEnd = "#fae188",
                },
                new HealthCare()
                {
                    Category = "Dead",
                    CategoryValue =trackdata.data[0].dead,
                    ChartData = caloriesBurnedData,
                    BackgroundGradientStart = "#ff7272",
                    BackgroundGradientEnd = "#f650c5"
                },
                new HealthCare()
                {
                    Category = "Recovered",
                    CategoryValue = trackdata.data[0].recovered,
                    ChartData = sleepTimeData,
                    BackgroundGradientStart = "#5e7cea",
                    BackgroundGradientEnd = "#1dcce3"
                },
               
            };
            
            var t1 = Task.Run(() => service.GetResponse(new Uri("https://www.trackcorona.live/api/provinces/Tamil%20Nadu")));
            t1.Wait();
            if (t1.Result != null)
            {
                var status = t.Result;
            }
            TrackData TrackdataState = JsonConvert.DeserializeObject<TrackData>(t1.Result);
            listItems = new ObservableCollection<HealthCare>()
            {
                new HealthCare()
                {
                    Category = TrackdataState.data[0].location,
                    CategoryValue = TrackdataState.data[0].confirmed,
                    CategoryPercentage=trackdata.data[0].updated,
                    BackgroundGradientStart = "#cf86ff"
                },
                new HealthCare()
                {
                    Category = "QuarantineCases",
                    CategoryPercentage=trackdata.data[0].updated,
                    BackgroundGradientStart = "#8691ff"
                },
                new HealthCare()
                {
                    Category = "CaseTimeReport",
                    CategoryPercentage=trackdata.data[0].updated,
                    BackgroundGradientStart = "#ff9686"
                },
                 new HealthCare()
                 {
                    Category = "State Wise",
                    CategoryPercentage=trackdata.data[0].updated,
                    BackgroundGradientStart = "#ff9686"
                 }
                  
            };

            this.ProfileImage = App.BaseImageUrl + "ProfileImage1.png";
            this.MenuCommand = new Command(this.MenuClicked);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the profile image path.
        /// </summary>
        public string ProfileImage { get; set; }

        /// <summary>
        /// Gets or sets the health care items collection.
        /// </summary>
        public ObservableCollection<HealthCare> CardItems
        {
            get
            {
                return this.cardItems;
            }

            set
            {
                this.cardItems = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the health care items collection.
        /// </summary>
        public ObservableCollection<HealthCare> ListItems
        {
            get
            {
                return this.listItems;
            }

            set
            {
                this.listItems = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Comments

        /// <summary>
        /// Gets or sets the command that will be executed when the menu button is clicked.
        /// </summary>
        public Command MenuCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Chart Data Collection
        /// </summary>
        private void GetChartData()
        {
            DateTime dateTime = new DateTime(2019, 5, 1);

            heartRateData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 15),
                new ChartDataPoint(dateTime.AddMonths(1), 20),
                new ChartDataPoint(dateTime.AddMonths(2), 17),
                new ChartDataPoint(dateTime.AddMonths(3), 23),
                new ChartDataPoint(dateTime.AddMonths(4), 18),
                new ChartDataPoint(dateTime.AddMonths(5), 25),
                new ChartDataPoint(dateTime.AddMonths(6), 19),
                new ChartDataPoint(dateTime.AddMonths(7), 21),
            };

            caloriesBurnedData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 940),
                new ChartDataPoint(dateTime.AddMonths(1), 960),
                new ChartDataPoint(dateTime.AddMonths(2), 942),
                new ChartDataPoint(dateTime.AddMonths(3), 957),
                new ChartDataPoint(dateTime.AddMonths(4), 940),
                new ChartDataPoint(dateTime.AddMonths(5), 942),
            };

            sleepTimeData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 7.8),
                new ChartDataPoint(dateTime.AddMonths(1), 7.2),
                new ChartDataPoint(dateTime.AddMonths(2), 8.0),
                new ChartDataPoint(dateTime.AddMonths(3), 6.8),
                new ChartDataPoint(dateTime.AddMonths(4), 7.6),
                new ChartDataPoint(dateTime.AddMonths(5), 7.0),
                new ChartDataPoint(dateTime.AddMonths(6), 7.5),
            };

            waterConsumedData = new ObservableCollection<ChartDataPoint>()
            {
                new ChartDataPoint(dateTime, 36),
                new ChartDataPoint(dateTime.AddMonths(1), 41),
                new ChartDataPoint(dateTime.AddMonths(2), 38),
                new ChartDataPoint(dateTime.AddMonths(3), 41),
                new ChartDataPoint(dateTime.AddMonths(4), 35),
                new ChartDataPoint(dateTime.AddMonths(5), 37),
                new ChartDataPoint(dateTime.AddMonths(6), 38),
                new ChartDataPoint(dateTime.AddMonths(7), 36),
            };
        }

        /// <summary>
        /// Invoked when the menu button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void MenuClicked(object obj)
        {
            // Do something
        }
       

        #endregion
    }
}

using Covid19.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using System.Timers;
using System.Threading;

namespace Covid19.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationTrace : ContentPage
    {
        public LocationTrace()
        {
            InitializeComponent();
            //StartTimer();
        } 
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    Position position = new Position(location.Latitude, location.Longitude);
                    MapSpan span = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(.444));

                    MyMap.MoveToRegion(span);

                }
                var Latitude = location.Latitude.ToString();
                var Longitude = location.Longitude.ToString();
                var service = new Service12();
                var SlotId = Application.Current.Properties["SlotId"].ToString();

                Uri u = new Uri("http://192.168.43.215/api/New/PositionData");
                var payload = new Dictionary<string, string>
                {
                    {"SlotId",SlotId },
                    {"Latitude",Latitude },
                    {"Longitude",Longitude }
                };
                string strpayload = JsonConvert.SerializeObject(payload);
                HttpContent content = new StringContent(strpayload, Encoding.UTF8, "application/json");
                var task = Task.Run(() => service.DataUpdate(u, content));
                task.Wait();
                if (task.Result)
                {

                }
                /* To Load multiples pin location*/

                LoadPinLocation();
            }
            catch (FeatureNotSupportedException e1)
            {
                throw e1;
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                throw fneEx;
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                throw pEx;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void LoadPinLocation()
        {
            try
            {                
                var service = new Service12();
                var task = Task.Run(() => service.GetData(new Uri("http://192.168.43.215/api/New/GetLocationData")));
                task.Wait();
                if (task.Result != null)
                {
                    var item = task.Result.Find(x => x.Latitude == "");
                     task.Result.Remove(item);
                     for(var i = 0; i < task.Result.Count; i++)
                     {
                        var pin = new Pin
                        {
                            Position=new Position(Convert.ToDouble(task.Result[i].Latitude),Convert.ToDouble(task.Result[i].Longitude)),
                            Label= task.Result[i].Name,
                            Address = task.Result[i].Address,
                            Type=PinType.Place
                        };

                        MyMap.Pins.Add(pin);
                     }
                }
             
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        
        private void StartTimer()
        {
            Device.StartTimer(System.TimeSpan.FromSeconds(10), () =>
            {
                 Device.BeginInvokeOnMainThread(UpdateData);
                 return true;

            });
        }
        private  void UpdateData()
        {
            LoadPinLocation();
        }
    }
}
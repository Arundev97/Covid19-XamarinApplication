using Covid19.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Covid19.Views.Profile
{
    /// <summary>
    /// Page to show Contact profile page
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactProfilePage
    {
        public ContactProfilePage(string SlotID)
        {
            InitializeComponent();

            Loaduser(SlotID);

        }
        protected void Loaduser(string SlotID)
        {
            try
            {
                var Data12 = new Service12(); 
                Uri u = new Uri("http://192.168.43.215/api/New/GetUserDataByUserId");
                var payload = new Dictionary<string, string>
                {
                    {"slotid",SlotID }
                };
                string strpayload = JsonConvert.SerializeObject(payload);
                HttpContent c = new StringContent(strpayload, Encoding.UTF8, "application/json");
                var t = Task.Run(() => Data12.GetDataByUserId(u, c));
                t.Wait();
                //LoadUsers Current Position i.e Latitude Longitude

                //LoadCurrentPosition();

                if (t.Result != null)
                {
                    var Name = t.Result[0].Name;
                    var Address = t.Result[0].Address;
                    var Email = t.Result[0].Email;
                    var Mobile = t.Result[0].MobileNumber;
                    var Address1 = t.Result[0].Address;
                    var Latitude =Convert.ToDouble(t.Result[0].Latitude);
                    var Longitude = Convert.ToDouble(t.Result[0].Longitude);
                    NameTxt.Text = Name;
                    EmailTxt.Text = Email;
                    MobileTxt.Text = Mobile;
                    AddressTxt.Text = Address1;
                    var device = Xamarin.Essentials.DeviceInfo.Model;
                    var pin = new Pin
                    {
                        Position = new Position(Latitude,Longitude),
                        Label = "Address",
                        Address = t.Result[0].Name,
                        Type = PinType.Place
                    };
                    mymap.Pins.Add(pin);
                    if (t.Result[0].Latitude!=null)
                    {
                        Position position = new Position(Latitude, Longitude);
                        MapSpan span = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(.444));

                        mymap.MoveToRegion(span);

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected async void LoadCurrentPosition()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);
                if (location != null)
                {
                    Position position = new Position(location.Latitude, location.Longitude);
                    MapSpan span = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(.444));

                    mymap.MoveToRegion(span);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }     


    }


}
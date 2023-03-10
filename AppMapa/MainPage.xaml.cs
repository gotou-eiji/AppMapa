using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Security.Cryptography;

namespace AppMapa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void brLocation_Clicked(object sender, EventArgs e)
        {
            try
            {
                var location = await Geolocation.GetLocationAsync(new GeolocationRequest() { DesiredAccuracy = GeolocationAccuracy.Best}); //vai receber latitude e longitude
                if (location != null)
                {
                    lblLatitude.Text = "Latitude: " + location.Latitude.ToString();
                    lblLongitude.Text = "Longitude: " + location.Longitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Falhou", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Falhou", pEx.Message, "OK");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Falhou", ex.Message, "OK");
            }
        }

        public async Task MostrarMapa()
        {
            var location = await Geolocation.GetLocationAsync(new GeolocationRequest() { DesiredAccuracy = GeolocationAccuracy.Best }); //vai receber latitude 
            var locationinfo = new Location(location.Latitude, location.Longitude);
            await Map.OpenAsync(locationinfo);
        }

        private async void btVerMapa_Clicked(object sender, EventArgs e)
        {
            await MostrarMapa();
        }
    }
}

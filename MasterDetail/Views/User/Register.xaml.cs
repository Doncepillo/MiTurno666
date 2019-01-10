using MasterDetail.Servicio;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail.Views.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();

            Cargar();
        }

        private void Cargar()
        {
            Cargapicker();
        }
        private async void Cargapicker()
        {
            string response = await Service.GetApi("api/supermarket");

            List<Supermercado> supermercados = JsonConvert.DeserializeObject<List<Supermercado>>(response);

            pckSupermarket.ItemsSource = supermercados;
            
        }
     

        private async void Registrar(object sender, EventArgs e)
        {
            string email = Email.Text;
            string pass = Contraseña.Text;

            EmpaqueModel empaque = new EmpaqueModel()
            {
                Email = email,
                Password = pass
            };

            

            HttpResponseMessage response = await Service.Post("api/User", empaque);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error de registro", "Informacion de usuario no corresponde", "Ok");

            }

        }
    }
}
using MasterDetail.Servicio;
using MasterDetail;
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

        private List<Supermercado> supermercados;
        private long market;


        public Register()
        {
            InitializeComponent();

            Cargar();
            this.market = 0;
        }

        private void Cargar()
        {
            Cargapicker();
        }
        private async void Cargapicker()
        {
            string response = await Service.GetAllApi("api/supermarket");

            List<Supermercado> supermercados2 = JsonConvert.DeserializeObject<List<Supermercado>>(response);
            pckSupermarket.ItemsSource = supermercados2;
            supermercados = supermercados2;

        }


        private async void Registrar(object sender, EventArgs e)
        {
            string email = Email.Text;
            string pass = Contraseña.Text;
            Supermercado sup = (Supermercado)pckSupermarket.SelectedItem;


            EmpaqueModel empaque = new EmpaqueModel()
            {
                Email = email,
                Password = pass,
                Supermarket = sup.Id
                
            };

            

            HttpResponseMessage response = await Service.Post("api/User", empaque);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                await Navigation.PushAsync(new Login());
            }
            else
            {
                await DisplayAlert("Error de registro", "Informacion de usuario no corresponde", "Ok");

            }

        }

        
    }
}
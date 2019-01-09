using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MasterDetail.Servicio;
using MasterDetail.Views.User;
using Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

        }

        private async void Ingresar(object sender, EventArgs e)
        {
            string email = Email.Text.ToString();
            string pass = Pass.Text.ToString();

            if (!(email.Equals("") ||pass.Equals("")))
            {
                EmpaqueModel empaque = new EmpaqueModel() { Email = email, Password = pass };

                HttpResponseMessage response =  await Service.autenticate("api/User/Authenticate", empaque);
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound) {
                    await Navigation.PushAsync(new MainPage()); 
                } 
                else
                {
                    await DisplayAlert("Error de Acceso", "Informacion de usuario no corresponde", "Ok");
            
                }
            }
            else
            {
                await DisplayAlert("Error de Acceso", "Debe ingresar datos en el formuladio", "Ok");
            }
            
        }

        private void Btn_Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());

        }
    }
}
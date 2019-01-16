using MasterDetail;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetail
{
    public partial class Master : ContentPage
    {
        EmpaqueModel empaque;
        public Master(EmpaqueModel empaque)
        {
            this.empaque = empaque;
            InitializeComponent();
        }

        private async void BtnMisTurnos_Clicked(object sender, EventArgs e)
        {
            

            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MisTurnos());
        }

        private async void BtnListaTurnos_Clicked(object sender, EventArgs e) 
        { 

            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListaTurnos());

        }

        private async void BtnMiPerfil_Clicked(object sender, EventArgs e)
        {
            
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MiPerfil(this.empaque));

        }

        private async void BtnMiRendimiento_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MiRendimiento());

        }

        private async void BtnMisNotificaciones_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MisNotificaciones());

        }

        private async void btnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["IsLoggedIn"] = false;
            await Application.Current.SavePropertiesAsync();
            Application.Current.MainPage = new Login();
        }
    }
}

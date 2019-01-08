using Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetail
{
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private async void BtnMisTurnos_Clicked(object sender, EventArgs e)
        {
            

            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MisTurnos());
        }

        private async void BtnListaTurnos_Clicked(object sender, EventArgs e) 
        {

            string path = "api/turn";

            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListaTurnos(path));

        }

        private async void BtnMiPerfil_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new MiPerfil());

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

    }
}

using System;
using System.Collections.Generic;

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
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListaTurnos());

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

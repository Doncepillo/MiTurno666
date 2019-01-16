using MasterDetail;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterDetail
{
    public partial class Detail : ContentPage
    {
        EmpaqueModel empaque;
        public Detail(EmpaqueModel empaque)
        {
            this.empaque = empaque;
            InitializeComponent();
        }

        public static Servicio.Service Servicio = new Servicio.Service();
        public Detail()
        {
            InitializeComponent();
        }

        private async void ListaTurnos(object sender, EventArgs e)
        {

            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new ListaTurnos());

        }

        private void MisTurnos(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MisTurnos());

        }


        private void MiRendimiento(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MiRendimiento());

        }

        private void MisNotificaciones(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MisNotificaciones());

        }



    }

}
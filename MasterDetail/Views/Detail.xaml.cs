using MasterDetail;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MasterDetail
{
    public partial class Detail : ContentPage
    {
        public Detail(EmpaqueModel empaque)
        {
            InitializeComponent();



            Bienvenido.Text = string.Format("Bienvenid@ a Miturno.com: {0} {1}", empaque.FirstName, empaque.LastName);
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

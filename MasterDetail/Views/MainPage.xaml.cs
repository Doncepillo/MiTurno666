using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetail
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new Master();
            this.Detail = new NavigationPage(new Detail());

            App.MasterD = this;
        }

        private void button_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaTurnos());

        }
        private void ListaTurnos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaTurnos());

        }

        private void MiPerfil(object sender, EventArgs e)
        {
            this.
            Navigation.PushAsync(new MiPerfil());

        }
        private void MiRendimiento(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MiRendimiento());

        }
        private void MisNotificaciones(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MisNotificaciones());

        }
        private void MisTurnos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MisTurnos());

        }

       
    }
}


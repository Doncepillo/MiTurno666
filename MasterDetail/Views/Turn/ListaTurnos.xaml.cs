using Modelo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetail
{
    public partial class ListaTurnos : ContentPage
    {
        public ListaTurnos(string path)
        {
            InitializeComponent();
            GrillaTurnosAsync(path);
        }

        private async Task GrillaTurnosAsync(string path)
        {
            
            List<Turnos> turnos = await Servicio.Service.turnos(path);
            LV_Turnos.ItemsSource = turnos;
        }

   
    }
}

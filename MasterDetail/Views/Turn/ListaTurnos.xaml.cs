using MasterDetail.Servicio;
using MasterDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetail
{
    public partial class ListaTurnos : ContentPage
    {
        

        public ListaTurnos()
        {
            InitializeComponent();
            Cargar();
        }

        private void Cargar() {

            GrillaTurnosAsync();
        }
        private async Task GrillaTurnosAsync()
        {
            string response = await Service.GetAllApi("api/turn");

            List<Turnos> turnos =  JsonConvert.DeserializeObject<List<Turnos>>(response);
            LV_Turnos.ItemsSource = turnos;
        }

   
    }
}

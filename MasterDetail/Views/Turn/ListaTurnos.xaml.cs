using MasterDetail.Servicio;
using Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MasterDetail
{
    public partial class ListaTurnos : ContentPage
    {
        string path = "api/turn";

        public ListaTurnos()
        {
            InitializeComponent();
            Cargar();
        }

        private void Cargar() {

            GrillaTurnosAsync(path);
        }
        private async Task GrillaTurnosAsync(string path)
        {
            string response = await Service.GetApi(path);

            List<Turnos> turnos =  JsonConvert.DeserializeObject<List<Turnos>>(response);
            LV_Turnos.ItemsSource = turnos;
        }

   
    }
}

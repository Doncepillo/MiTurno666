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
            waitActivityIndicator.IsRunning = true;
            string response = await Service.GetAllApi("api/turn");

            List<Turnos> turnos =  JsonConvert.DeserializeObject<List<Turnos>>(response);
            waitActivityIndicator.IsRunning = false;

             LV_Turnos.ItemsSource = turnos;
        }

        private void TomarTurno(object sender, ItemTappedEventArgs e)
        {
            Turnos item =(Turnos) e.Item;

            //tengo que cambiar en la base de datos la funcionalidad del campo Maximuncap
            Turnos turno = new Turnos()
            {
                Id=item.Id
                
                
            };

          //  Service.Post("api/",)

            DisplayAlert(" ", item.MaximunCap.ToString(), "ok");
            
            
            
        }

       
    }
}

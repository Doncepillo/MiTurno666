using MasterDetail.Servicio;
using MasterDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;
using System.Linq;
using System.Net.Http;

namespace MasterDetail
{
    public partial class ListaTurnos : ContentPage
    {

        EmpaqueModel empaq = new EmpaqueModel();
        public ListaTurnos(EmpaqueModel empaque)
        {
            this.empaq = empaque;
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "MiTurnoAPP");

            Cargar();

        }

        private void Cargar()
        {
            GrillaTurnosAsync();
        }

        private async Task GrillaTurnosAsync()
        {
            waitActivityIndicator.IsRunning = true;
            string response = await Service.GetAllApi("api/turn");

            List<Turnos> turnos = JsonConvert.DeserializeObject<List<Turnos>>(response);
            waitActivityIndicator.IsRunning = false;

            LV_Turnos.ItemsSource = turnos;

        }






        private async void TomarTurno(object sender, ItemTappedEventArgs e)
        {

            Turnos item = (Turnos)e.Item;
            List<Turnos> listaturnos = (List<Turnos>)LV_Turnos.ItemsSource;



            //tengo que cambiar en la base de datos la funcionalidad del campo Maximuncap
            TraceabilityWorkShift turnotomado = new TraceabilityWorkShift()
            {

                ActualState = 0,
                IdWor = item.Id,
                UserId = empaq.Id,
                EffectiveQuantity = 1

            };


            try
            {
                HttpResponseMessage response = await Service.Post("api/TraceabilityWorkShift", turnotomado);
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    foreach (var turn in LV_Turnos.ItemsSource as List<Turnos>)
                    {
                        if (turn.Id == item.Id)
                        {
                            listaturnos.Remove(turn);
                        }
                    }
                    LV_Turnos.ItemsSource = null;
                    LV_Turnos.ItemsSource = listaturnos;


                    await DisplayAlert("Exito", "Turno asignado Exitosamente", "OK", "Cancelar");
                }
                else
                {

                    await DisplayAlert("Fallo", "Error al asignar turno", "OK");

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fallo", "Error al asignar turno " + ex, "OK");
            }

        }



    }
}

using MasterDetail.Servicio;
using MasterDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace MasterDetail
{
    public partial class MisTurnos : ContentPage
    {

        EmpaqueModel em = new EmpaqueModel();
        public MisTurnos(EmpaqueModel empaque)
        {
            em = empaque;
            InitializeComponent();
            Cargar();
            NavigationPage.SetBackButtonTitle(this, "MiTurnoAPP");
        }

        private void Cargar()
        {
            GrillaTurnosAsync();
        }
        private async Task GrillaTurnosAsync()
        {
            waitActivityIndicator.IsRunning = true;
            string response = await Service.GetAllApi("api/TraceabilityWorkShift?id="+em.Id.ToString());

            List<TraceabilityWorkShift> Mturnos = JsonConvert.DeserializeObject<List<TraceabilityWorkShift>>(response);
            waitActivityIndicator.IsRunning = false;

            Mis_Turnos.ItemsSource = Mturnos;
        }

        private async void RegalarTurno_Clicked(object sender, EventArgs e)
        {
            
            TraceabilityWorkShift turnoRegalado = (TraceabilityWorkShift)sender;

            HttpResponseMessage response = await Service.Delete("api/TraceabilityWorkShift/" + turnoRegalado.Id);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound && response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
            {
                await DisplayAlert("Exito", "Tu turno ha sido regalado", "OK");
            }
        }

        private void IntercambiarTurno_Clicked(object sender, EventArgs e)
        {

        }
    }
}

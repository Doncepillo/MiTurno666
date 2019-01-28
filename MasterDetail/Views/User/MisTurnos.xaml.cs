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

            try
            {
                using (var datos = new DataAccess())
                {
                    List<TraceabilityWorkShift> turnosTomados = new List<TraceabilityWorkShift>();
                    turnosTomados = datos.GetTrazas();
                    if (Mis_Turnos.ItemsSource == null || turnosTomados.Count == 0)
                    {
                        string response = await Service.GetAllApi("api/TraceabilityWorkShiftsByEmpaque?Id=" + em.Id.ToString());

                        List<TraceabilityWorkShift> Mturnos = JsonConvert.DeserializeObject<List<TraceabilityWorkShift>>(response);

                        waitActivityIndicator.IsRunning = false;

                        foreach (TraceabilityWorkShift item in Mturnos)
                        {
                            datos.InsertTraza(item);
                        }

                        Mis_Turnos.ItemsSource = Mturnos;
                    }

                    else
                    {
                        Mis_Turnos.ItemsSource = turnosTomados;
                    }
                }
            }

            catch (Exception ex)
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Error", "Fallo la conexión :  " + ex, "Ok");
            }
        }

        private async void RegalarTurno_Clicked(object sender, EventArgs e)
        {
            TraceabilityWorkShift turnoRegalado = (TraceabilityWorkShift)sender;

            HttpResponseMessage response = await Service.Delete("api/TraceabilityWorkShift/" + turnoRegalado.Id);
            if (response.StatusCode != System.Net.HttpStatusCode.NotFound && response.StatusCode != System.Net.HttpStatusCode.InternalServerError)
            {
                await DisplayAlert("Éxito", "Tu turno ha sido regalado", "Ok");
            }
        }

        private void IntercambiarTurno_Clicked(object sender, EventArgs e)
        {

        }
    }
}

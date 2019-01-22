using MasterDetail.Servicio;
using MasterDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using System.Net.Http;

namespace MasterDetail
{
    public partial class MiPerfil : ContentPage
    {
        EmpaqueModel empa;
        List<Supermercado> listaSuperm;
        public MiPerfil(EmpaqueModel empaque)
        {
            this.empa = empaque;
            InitializeComponent();
            Carga(empa);
        }

        private async void Carga(EmpaqueModel empaque)
        {
            await CargaPerfil(empaque);

        }

        private async Task CargaPerfil(EmpaqueModel emp)
        {
            string response = await Service.GetAllApi("api/supermarket");

            List<Supermercado> supermercados2 = JsonConvert.DeserializeObject<List<Supermercado>>(response);
            lblSuperm.ItemsSource = supermercados2;
            listaSuperm = supermercados2;

            lblRut.Text = emp.Rut.ToString();
            lblEmail.Text = emp.Email.ToString();
            lblName.Text = emp.FirstName.ToString();
            lblLastname.Text = emp.LastName.ToString();
            dtpNacimiento.Date = emp.BirthDate;
            lblSuperm.SelectedItem = emp.Supermarket;
            lblAdress.Text = emp.Address.ToString();
            lblPhone.Text = emp.PhoneNumber.ToString();
            lblJobTitle.Text = emp.TypeUser.ToString();

        }

        private async void Btn_EditarPerfil_Clicked(object sender, EventArgs e)
        {
            Btn_EditarPerfil.IsEnabled = false;
            waitActivityIndicator.IsRunning = true;

            Supermercado super = (Supermercado)lblSuperm.SelectedItem;

            EmpaqueModel empaque = new EmpaqueModel()
            {
                Id = empa.Id,
                Rut = Convert.ToInt32(lblRut.Text),
                Email = lblEmail.Text,
                Password = lblPass.Text,
                FirstName = lblName.Text,
                LastName = lblLastname.Text,
                BirthDate = dtpNacimiento.Date,
                Address = lblAdress.Text,
                PhoneNumber = Convert.ToInt32(lblPhone.Text),
                Supermarket = super.Id,
                JobTitle = lblJobTitle.Text

            };

            try
            {
                HttpResponseMessage response = await Service.Put("api/user/" + empa.Id.ToString(), empaque);
                if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Éxito al editar", "Éxito al editar información", "Ok");
                    Btn_EditarPerfil.IsEnabled = true;
                    return;

                }
                else
                {
                    waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Error de conexión", "Error inesperado al editar sus datos", "Ok");
                    Btn_EditarPerfil.IsEnabled = true;

                    return;
                }

            }
            catch (Exception ex)
            {
                Btn_EditarPerfil.IsEnabled = true;

                await DisplayAlert("Error de edición", "Error al editar empaque "+ ex, "Ok");
                return;
            }
        }
    }
}
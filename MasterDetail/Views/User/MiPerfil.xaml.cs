using MasterDetail.Servicio;
using MasterDetail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace MasterDetail
{
    public partial class MiPerfil : ContentPage
    {
       

        public MiPerfil(EmpaqueModel empaque)
        {
            InitializeComponent();
            Carga(empaque);
        }

        private void Carga(EmpaqueModel empaque)
        {
            CargaPerfil(empaque);
        }

        private async Task CargaPerfil(EmpaqueModel emp)
        {

            

            

            lblRut.Text = emp.Rut.ToString();
            lblName.Text = emp.FirstName.ToString();
            lblLastname.Text = emp.LastName.ToString();
            lblBirthdate.Text = emp.BirthDate.ToString();
            lblAdress.Text = emp.Address.ToString();
            lblPhone.Text = emp.PhoneNumber.ToString();
            lblSuperm.Text = emp.Supermarket.ToString();
            lblJobTitle.Text = emp.TypeUser.ToString();

            

        }
    }
}



using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterDetail.Servicio;
using MasterDetail.Views.User;
using Modelo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

        }

        private void Ingresar(object sender, EventArgs e)
        {
            string email = Email.Text.ToString();
            string pass = Pass.Text.ToString();

            if (!(email.Equals("") ||pass.Equals("")))
            {
                
                string path = "api/Login?email=" + email + "&contra=" +pass ;
                Task<EmpaqueModel> existe = Service.Login(path);
                if (existe != null) { 
                Navigation.PushAsync(new MainPage());

                }
                else
                {
                    lblError.IsVisible = true;
                    lblError.Text = "datos erroneos";
                }
            }
            else
            {
                lblError.IsVisible = true;
                lblError.Text = "Ingrese datos";
            }
            
        }
    }
}
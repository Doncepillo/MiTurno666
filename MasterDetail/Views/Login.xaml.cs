using System;
using System.Collections.Generic;
using MasterDetail.Views.User;
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
            Navigation.PushAsync(new MainPage());
        }
    }
}
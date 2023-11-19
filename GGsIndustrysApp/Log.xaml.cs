using GGsIndustrysApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GGsIndustrysApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Log : ContentPage
    {
        public Log()
        {
            InitializeComponent();
        }

        public async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCorreo.Text))
            {
                await DisplayAlert("Aviso", "El Correo no debe estar vacio", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                await DisplayAlert("Aviso", "La Contraseña no debe estar vacia", "Ok");
                return;
            }

            var resultado = await App.SQLiteDB.GetUsersValidate(txtCorreo.Text, txtPwd.Text);

            if(resultado.Count >0)
            {
                txtCorreo.Text = "";
                txtPwd.Text = "";

                await Navigation.PushAsync(new MainPage());
            }
            else 
            {
                txtCorreo.Text = "";
                txtPwd.Text = "";

                await DisplayAlert("Aviso", "El Correo o La Contraseña no son correctos", "Ok");
                return;
            }
        }

        private async void Button_Clicked_Registrar(object sender, EventArgs e)
        {
            txtCorreo.Text = "";
            txtPwd.Text = "";
            await Navigation.PushAsync(new Registro());
        }
    }
}
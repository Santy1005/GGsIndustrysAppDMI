using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SQLite;
using GGsIndustrysApp.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GGsIndustrysApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmailReg.Text))
            { 
                await DisplayAlert("AVISO", "Debe escribir un email en el campo", "Ok"); 
                return;
            }
             
            if (string.IsNullOrEmpty(txtContraReg.Text)) 
            {
                await DisplayAlert("AVISO", "Debe escribir una contraseña en el campo", "Ok");
                return;
            }
               
            if (string.IsNullOrEmpty(txtNombreReg.Text)) 
            {
                await DisplayAlert("AVISO", "Debe escribir el nombre completo en el campo", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(txtEdadReg.Text)) 
            {
                await DisplayAlert("AVISO", "Debe escribir la edad en el campo", "Ok");
                return;
            }

            Users usr = new Users()
            {
               Corre = txtEmailReg.Text,
               Pwd= txtContraReg.Text,
               NombreCompleto= txtNombreReg.Text,
               Edad = int.Parse(txtEdadReg.Text),
               Fecha = DateTime.Now,

            };

            await App.SQLiteDB.SaveUserModelsAsync(usr);
            await DisplayAlert("AVISO", "El registro quedo guardado", "ok");
            txtEmailReg.Text = " ";
            txtContraReg.Text = " ";
            txtNombreReg.Text= " ";
            txtEdadReg.Text = " ";

            //await Navigation.PushAsync(new Log());
            await Navigation.PopAsync();

        }
    }
}
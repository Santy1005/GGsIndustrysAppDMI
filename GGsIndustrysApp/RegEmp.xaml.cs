using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GGsIndustrysApp.Models;

namespace GGsIndustrysApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegEmp : ContentPage
    {
        public RegEmp()
        {
            InitializeComponent();
            llenarDatos();
        }

        public async void llenarDatos()
        {
            var EmpleadoList = await App.SQLiteDB.GetEmpleadosAsync();
            if (EmpleadoList != null)
            {
                lsEmpleado.ItemsSource = EmpleadoList;
            }
        }

        private async void Button_Save_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Empleado emple = new Empleado()
                {
                    Nombre = txtName.Text,
                    Direccion = txtDireccion.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Telefono = double.Parse(txtTel.Text),
                    Curp = txtCurp.Text,
                    TipoEmp = txtTipoEmp.Text,
                };

                await App.SQLiteDB.SaveEmpleadosAsync(emple);

                txtName.Text = "";
                txtDireccion.Text = "";
                txtEdad.Text = "";
                txtTel.Text = "";
                txtCurp.Text = "";
                txtTipoEmp.Text = "";

                await DisplayAlert("AVISO", "Guardado de forma exitosa", "Ok");

                llenarDatos();

            }
            else
            {
                await DisplayAlert("AVISO", "Ingresar todos los datos", "Ok");
            }
        }

        public async void Button_Actualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdEmp.Text))
            {
                Empleado empleado = new Empleado()
                {
                    IdEmp = int.Parse(txtIdEmp.Text),
                    Nombre = txtName.Text,
                    Direccion = txtDireccion.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Telefono = double.Parse(txtTel.Text),
                    Curp = txtCurp.Text,
                    TipoEmp = txtTipoEmp.Text,

                };

                await App.SQLiteDB.SaveEmpleadosAsync(empleado);

                txtIdEmp.Text = " ";
                txtName.Text = "";
                txtDireccion.Text = "";
                txtEdad.Text = "";
                txtTel.Text = "";
                txtCurp.Text = "";
                txtTipoEmp.Text = "";

                txtIdEmp.IsVisible = false;
                btnGuardar.IsVisible = true;
                btnActualizar.IsVisible = false;
                btnDelete.IsVisible = false;

                await DisplayAlert("AVISO", "Se Actualizo Registro de Manera Exitosa", "Ok");
                llenarDatos();

            }
        }

        public async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            var empleado = await App.SQLiteDB.GetEmpleadoByIdAsync(int.Parse(txtIdEmp.Text));

            if (empleado != null)
            {
                await App.SQLiteDB.DeleteEmpleadoAsync(empleado);
                await DisplayAlert("Aviso", "Se elimino registro de manera exitosa", "ok");

                txtIdEmp.Text = " ";
                txtName.Text = "";
                txtDireccion.Text = "";
                txtEdad.Text = "";
                txtTel.Text = "";
                txtCurp.Text = "";
                txtTipoEmp.Text = "";

                txtIdEmp.IsVisible = false;
                btnGuardar.IsVisible = true;
                btnActualizar.IsVisible = false;
                btnDelete.IsVisible = false;

                llenarDatos();
            }
        }

        private async void lstEmpleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Empleado)e.SelectedItem;

            btnGuardar.IsVisible = false;
            txtIdEmp.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnDelete.IsVisible = true;
            //btnBack.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.IdEmp.ToString()))
            {
                var emplea = await App.SQLiteDB.GetEmpleadoByIdAsync(obj.IdEmp);

                if (emplea != null)
                {
                    txtIdEmp.Text = emplea.IdEmp.ToString();
                    txtName.Text = emplea.Nombre;
                    txtDireccion.Text = emplea.Direccion;
                    txtEdad.Text = emplea.Edad.ToString();
                    txtTel.Text = emplea.Telefono.ToString();
                    txtCurp.Text = emplea.Curp.ToString();
                    txtTipoEmp.Text = emplea.TipoEmp.ToString();
                }
            }
        }

        public bool ValidarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtTel.Text))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtCurp.Text))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtTipoEmp.Text))
            {
                respuesta = false;
            }

            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private void LimpiarCampos()
        {
            txtName.Text = "";
            txtDireccion.Text = "";
            txtEdad.Text = "";
            txtTel.Text = "";
            txtCurp.Text = "";
            txtTipoEmp.Text = "";

            LimpiarCampos();
        }

    }
}
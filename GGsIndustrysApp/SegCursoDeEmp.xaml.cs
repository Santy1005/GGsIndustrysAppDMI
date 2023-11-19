using GGsIndustrysApp.Models;
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
    public partial class SegCursoDeEmp : ContentPage
    {
        public SegCursoDeEmp()
        {
            InitializeComponent();
            txtEstatus.Items.Add("Programado");
            txtEstatus.Items.Add("En proceso");
            txtEstatus.Items.Add("Completado");
            llenarDatos();
            llenarDatos2();
            
        }

        private void txtEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public async void llenarDatos()
        {
            var SeguimientoList = await App.SQLiteDB.GetSeguimientosAsync();
            if (SeguimientoList != null)
            {
                lsSeguimiento.ItemsSource = SeguimientoList;
            }
        }
        public async void txtGuardaSeg_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Seguimiento seg = new Seguimiento()
                {
                    NombreEmpleado = txtNombreEmp.Title,
                    NombreCurso = txtNombreCurso.Title,
                    Lugar = txtLugCurso.Text,
                    //Fecha = DateTime.Parse(Title),
                    //Hora = DateTime.Parse(Title),
                    Estatus = txtEstatus.Title,
                    Calificacion = int.Parse(txtCal.Text),
                };

                await App.SQLiteDB.SaveSeguimientosAsync(seg);

                txtNombreEmp.Title = "";
                txtNombreCurso.Title = "";
                txtLugCurso.Text = "";
                //txtFecha. = "";
                //txtHora.Text = "";
                txtCal.Text = "";

                await DisplayAlert("AVISO", "Guardado de forma exitosa", "Ok");

                llenarDatos();

            }
            else
            {
                await DisplayAlert("AVISO", "Ingresar todos los datos", "Ok");
            }
        }

        public async void llenarDatos2() 
        {
            var EmpleadoList2 = await App.SQLiteDB.GetEmpleadosAsync();
            if (EmpleadoList2 != null) 
            {
                txtNombreEmp.ItemsSource= EmpleadoList2;
            }

            var CursoList2 = await App.SQLiteDB.GetCursosAsync();
            if (CursoList2 != null)
            {
                txtNombreCurso.ItemsSource = CursoList2;
            }
        }

        public async void txtUpdate_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdSeg.Text))
            {
                Seguimiento seguimiento = new Seguimiento()
                {
                    NombreEmpleado = txtNombreEmp.Title,
                    NombreCurso = txtNombreCurso.Title,
                    Lugar = txtLugCurso.Text,
                    //Fecha = DateTime.Parse(Title),
                    //Hora = DateTime.Parse(Title),
                    Estatus = txtEstatus.Title,
                    Calificacion = int.Parse(txtCal.Text),

                };

                await App.SQLiteDB.SaveSeguimientosAsync(seguimiento);

                txtNombreEmp.Title = "";
                txtNombreCurso.Title = "";
                txtLugCurso.Text = "";
                //txtFecha. = "";
                //txtHora.Text = "";
                txtCal.Text = "";

                txtIdSeg.IsVisible = false;
                txtGuardaSeg.IsVisible = true;
                txtUpdate.IsVisible = false;
                btnDel.IsVisible = false;

                await DisplayAlert("AVISO", "Se Actualizo Registro de Manera Exitosa", "Ok");
                llenarDatos();

            }
        }

        private async void lstSeguimientos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Seguimiento)e.SelectedItem;

            txtGuardaSeg.IsVisible = false; 
            txtIdSeg.IsVisible = true;
            txtUpdate.IsVisible = true;
            btnDel.IsVisible = true;
            //btnBack.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.IdSeg.ToString()))
            {
                var segui = await App.SQLiteDB.GetSeguimientoByIdAsync(obj.IdSeg);

                if (segui != null)
                {
                    txtIdSeg.Text = segui.IdSeg.ToString();
                    txtNombreEmp.Title = segui.NombreEmpleado;
                    txtNombreCurso.Title = segui.NombreCurso;
                    txtLugCurso.Text = segui.ToString();
                    //txtFecha = segui.Fecha.ToString();
                    //txtHora.Date = segui.Hora.ToString();
                    txtCal.Text = segui.Calificacion.ToString();
                }
            }
        }

        public bool ValidarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(txtNombreEmp.Title))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtNombreCurso.Title))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtLugCurso.Text))
            {
                respuesta = false;
            }

            /*else if (string.IsNullOrEmpty(txtFecha.Date))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtHora.Text))
            {
                respuesta = false;
            }*/

            else if (string.IsNullOrEmpty(txtCal.Text))
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
            txtNombreEmp.Title = "";
            txtNombreCurso.Title = "";
            txtLugCurso.Text = "";
            //txtFecha. = "";
            //txtHora.Text = "";
            txtCal.Text = "";

            LimpiarCampos();
        }

        private async void btnDel_Clicked(object sender, EventArgs e)
        {
            var segui = await App.SQLiteDB.GetSeguimientoByIdAsync(int.Parse(txtIdSeg.Text));

            if (segui != null)
            {
                await App.SQLiteDB.DeleteSeguimientoAsync(segui);
                await DisplayAlert("Aviso", "Se elimino registro de manera exitosa", "ok");

                txtNombreEmp.Title = "";
                txtNombreCurso.Title = "";
                txtLugCurso.Text = "";
                //txtFecha. = "";
                //txtHora.Text = "";
                txtCal.Text = "";

                txtIdSeg.IsVisible = false;
                txtGuardaSeg.IsVisible = true;
                txtUpdate.IsVisible = false;
                btnDel.IsVisible = false;

                llenarDatos();
            }
        }
    }
}
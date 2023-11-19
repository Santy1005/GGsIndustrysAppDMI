using GGsIndustrysApp.Models;
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
    public partial class RegCurso : ContentPage
    {
        public RegCurso()
        {
            InitializeComponent();
            llenarDatos();
        }

        public async void llenarDatos()
        {
            var CursoList = await App.SQLiteDB.GetCursosAsync();
            if (CursoList != null)
            {
                lsCurso.ItemsSource = CursoList;
            }
        }

        private async void Button_Save_Clicked(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Curso cur = new Curso()
                {
                    Nombre = txtNameCurso.Text,
                    Tipo = txtTipoCurso.Text,
                    Descripcion = txtDescripcion.Text,
                    Tiempo = txtHoras.Text,
                };

                await App.SQLiteDB.SaveCursosAsync(cur);

                txtNameCurso.Text = "";
                txtTipoCurso.Text = "";
                txtDescripcion.Text = "";
                txtHoras.Text = "";

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
            if (!string.IsNullOrEmpty(txtIdCurso.Text))
            {
                Curso curso = new Curso()
                {
                    IdCurso = int.Parse(txtIdCurso.Text),
                    Nombre = txtNameCurso.Text,
                    Tipo = txtTipoCurso.Text,
                    Descripcion = txtDescripcion.Text,
                    Tiempo = txtHoras.Text,

                };

                await App.SQLiteDB.SaveCursosAsync(curso);

                txtIdCurso.Text = " ";
                txtNameCurso.Text = "";
                txtTipoCurso.Text = "";
                txtDescripcion.Text = "";
                txtHoras.Text = "";


                txtIdCurso.IsVisible = false;
                btnGuardar.IsVisible = true;
                btnActualizar.IsVisible = false;
                btnDelete.IsVisible = false;

                await DisplayAlert("AVISO", "Se Actualizo Registro de Manera Exitosa", "Ok");
                llenarDatos();

            }
        }

        public async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            var curso = await App.SQLiteDB.GetCursoByIdAsync(int.Parse(txtIdCurso.Text));

            if (curso != null)
            {
                await App.SQLiteDB.DeleteCursoAsync(curso);
                await DisplayAlert("Aviso", "Se elimino registro de manera exitosa", "ok");

                txtIdCurso.Text = " ";
                txtNameCurso.Text = "";
                txtTipoCurso.Text = "";
                txtDescripcion.Text = "";
                txtHoras.Text = "";

                txtIdCurso.IsVisible = false;
                btnGuardar.IsVisible = true;
                btnActualizar.IsVisible = false;
                btnDelete.IsVisible = false;

                llenarDatos();
            }
        }

        private async void lstCursos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Curso)e.SelectedItem;

            btnGuardar.IsVisible = false;
            txtIdCurso.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnDelete.IsVisible = true;
            //btnBack.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.IdCurso.ToString()))
            {
                var curs = await App.SQLiteDB.GetCursoByIdAsync(obj.IdCurso);

                if (curs != null)
                {
                    txtIdCurso.Text = curs.IdCurso.ToString();
                    txtNameCurso.Text = curs.Nombre;
                    txtTipoCurso.Text = curs.Tipo;
                    txtDescripcion.Text = curs.Descripcion.ToString();
                    txtHoras.Text = curs.Tiempo.ToString();

                }
            }
        }

        public bool ValidarDatos()
        {
            bool respuesta;

            if (string.IsNullOrEmpty(txtNameCurso.Text))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtTipoCurso.Text))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                respuesta = false;
            }

            else if (string.IsNullOrEmpty(txtHoras.Text))
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
            txtNameCurso.Text = "";
            txtTipoCurso.Text = "";
            txtDescripcion.Text = "";
            txtHoras.Text = "";

            LimpiarCampos();
        }

    }
}
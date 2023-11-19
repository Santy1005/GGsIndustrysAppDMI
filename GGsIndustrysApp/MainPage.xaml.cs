using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GGsIndustrysApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void Button_RegEmp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegEmp());
        }

        public async void Button_RegCurso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegCurso());
        }

        public async void Button_SegCursoDeEmp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SegCursoDeEmp());
        }
    }
}

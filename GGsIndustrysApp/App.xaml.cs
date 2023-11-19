using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GGsIndustrysApp.Data;
using System.IO;
using GGsIndustrysApp.Data;
using GGsIndustrysApp;

namespace GGsIndustrysApp
{
    public partial class App : Application
    {
        private static SQLiteHelper db;
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new Log());
        }

        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empresa.db3"));
                }
                return db;
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

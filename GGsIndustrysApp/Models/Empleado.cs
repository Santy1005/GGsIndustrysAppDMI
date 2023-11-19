 using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GGsIndustrysApp.Models
{
    public class Empleado
    {
        [PrimaryKey, AutoIncrement]
        public int IdEmp { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Direccion { get; set; }
        [MaxLength(50)]
        public int Edad { get; set; }
        public double Telefono { get; set; }
        public string Curp { get; set; }
        [MaxLength(50)]
        public string TipoEmp { get; set; }

        public string FullName { get { return Nombre; } }

    }
}
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GGsIndustrysApp.Models
{
    public class Curso
    {
        [PrimaryKey, AutoIncrement]
        public int IdCurso { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Tipo { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }
        [MaxLength(50)]
        public string Tiempo { get; set; }

        public string Cursos { get { return Nombre; } }

    }
}
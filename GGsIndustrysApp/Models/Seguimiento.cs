using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGsIndustrysApp.Models
{
    public class Seguimiento
    {
        [PrimaryKey, AutoIncrement]
        public int IdSeg { get; set; }
        [MaxLength(100)]

        public string NombreEmpleado { get; set;}
        [MaxLength(100)]

        public string NombreCurso { get; set;}
        [MaxLength(100)]

        public string Lugar { get; set;}

        //public DateTime Fecha { get; set;}

        //public DateTime Hora { get; set;}

        public string Estatus { get; set;}

        public int Calificacion { get; set; }

    }
}

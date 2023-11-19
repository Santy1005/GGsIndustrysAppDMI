using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;

namespace GGsIndustrysApp.Models
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int IdUser { get; set; }
        [MaxLength(50)]
        public string Corre { get; set; }
        [MaxLength(50)]
        public string Pwd { get; set; }
        [MaxLength(50)]
        public string NombreCompleto { get; set; }
        [MaxLength(50)]
        public int Edad { get; set; }
        public DateTime Fecha { get; set; }
    }
}

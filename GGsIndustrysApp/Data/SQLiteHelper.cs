using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GGsIndustrysApp.Models;
using System.Security.Principal;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Security.Cryptography.X509Certificates;
using Xamarin.Essentials;
using System.Security.Cryptography;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace GGsIndustrysApp.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Empleado>().Wait();

            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Curso>().Wait();

            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Users>().Wait();

            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Seguimiento>().Wait();

        }

        public Task<int> SaveEmpleadosAsync(Empleado emple)
        {
            if (emple.IdEmp != 0)
            {
                return db.UpdateAsync(emple);
            }
            else
            {
                return db.InsertAsync(emple);
            }
        }

        public Task<Empleado> GetEmpleadoByIdAsync(int IdEmp)
        {
            return db.Table<Empleado>().Where(a => a.IdEmp == IdEmp).FirstOrDefaultAsync();
        }

        public Task<int> DeleteEmpleadoAsync(Empleado empleado)
        {
            return db.DeleteAsync(empleado);
        }

        public Task<List<Empleado>> GetEmpleadosAsync()
        {
            return db.Table<Empleado>().ToListAsync();

        }


        public Task<int> SaveCursosAsync(Curso cur)
        {
            if (cur.IdCurso != 0)
            {
                return db.UpdateAsync(cur);
            }
            else
            {
                return db.InsertAsync(cur);
            }
        }

        public Task<Curso> GetCursoByIdAsync(int IdCurso)
        {
            return db.Table<Curso>().Where(a => a.IdCurso == IdCurso).FirstOrDefaultAsync();
        }

        public Task<int> DeleteCursoAsync(Curso cur)
        {
            return db.DeleteAsync(cur);
        }

        public Task<List<Curso>> GetCursosAsync()
        {
            return db.Table<Curso>().ToListAsync();

        }

        public Task<int>SaveUserModelsAsync(Users usr) 
        {
            if (usr.IdUser != 0) 
            {
                return db.UpdateAsync(usr);
            }
            else 
            { 
                return db.InsertAsync(usr); 
            }

        }

        public Task<List<Users>>GetUsersValidate(string email, string password)
        {
            return db.QueryAsync<Users>("SELECT * FROM Users WHERE Corre = '" + email + "' AND Pwd = '" + password + "'");
        }

        public Task<int> SaveSeguimientosAsync(Seguimiento seg)
        {
            if (seg.IdSeg != 0)
            {
                return db.UpdateAsync(seg);
            }
            else
            {
                return db.InsertAsync(seg);
            }
        }

        public Task<Seguimiento> GetSeguimientoByIdAsync(int IdSeg)
        {
            return db.Table<Seguimiento>().Where(a => a.IdSeg == IdSeg).FirstOrDefaultAsync();
        }

        public Task<List<Seguimiento>> GetSeguimientosAsync()
        {
            return db.Table<Seguimiento>().ToListAsync();

        }

        public Task<int> DeleteSeguimientoAsync(Seguimiento seg)
        {
            return db.DeleteAsync(seg);
        }

        /*public void OnPickerItemSelected(object sender, EventArgs e)
        {
            var EmpSeleccionado = (Seguimiento)txtNombreEmp.SelectedItem;

            if (EmpSeleccionado != null)
            {
                // Guarda el usuario seleccionado en la base de datos
                db.InsertAsync(EmpSeleccionado);
            }
        }*/

        /*public void OnFechaChanged(object sender, DateChangedEventArgs e)
        {
            DateTime nuevaFecha = e.NewDate;

            // Guarda la fecha seleccionada en la base de datos
            Seguimiento segi = new Seguimiento
            {
                Fecha = nuevaFecha
            };

            db.InsertAsync(segi);
        }*/


    }
}
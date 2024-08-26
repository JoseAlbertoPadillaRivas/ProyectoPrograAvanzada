using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyectoGrupo_1.Entidades;
using proyectoGrupo_1.BaseDatos;

namespace proyectoGrupo_1.Models
{
    public class UsuarioModel
    {

        public bool RegistrarUsuario(Usuario user)
        {
            try { 
            var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.RegistrarUsuario(user.Cedula, user.Nombre, user.Correo, user.Contrasenna);
            }

            return (rowsAffected > 0 ? true : false);
            } catch { return false; }
        }

        public IniciarSesion_Result IniciarSesion(Usuario user)
        {
            using (var context = new proyectoEntities1())
            {
                return context.IniciarSesion(user.Correo, user.Contrasenna).FirstOrDefault();
            }
        }

        public List<tUsuario> ConsultarUsuarios()
        {
            using (var context = new proyectoEntities1())
            {
                int idSesion = int.Parse(HttpContext.Current.Session["idUsuario"].ToString());

                return (from x in context.tUsuario
                        where x.id != idSesion
                        select x).ToList();
            }
        }

        public tUsuario ConsultarUsuario(int id)
        {
            using (var context = new proyectoEntities1())
            {
                return (from x in context.tUsuario
                        where x.id == id
                        select x).FirstOrDefault();
            }
        }

        public ValidarUsuarioIdentificacion_Result ConsultarUsuarioCedula(string Cedula)
        {
            using (var context = new proyectoEntities1())
            {
                return context.ValidarUsuarioIdentificacion(Cedula).FirstOrDefault();
            }
        }

        public bool CambiarEstadoUsuario(Usuario user)
        {
            try
            {
                var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.CambiarEstadoUsuario(user.id);
            }

            return (rowsAffected > 0 ? true : false);
            } catch { return false; }
        }

        public bool ActualizarUsuario(Usuario user)
        {
            try
            {
                var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.ActualizarUsuario(user.Cedula, user.Nombre, user.Correo, user.idRol, user.id);
            }

            return (rowsAffected > 0 ? true : false);
            } catch { return false; }
        }

        public bool CambiarContrasennaUsuario(int id, string contrasennaTemporal, bool EsClaveTemporal, DateTime ClaveVencimiento)
        {
            try
            {
                var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                var datos = (from x in context.tUsuario
                             where x.id == id
                             select x).FirstOrDefault();

                datos.Contrasenna = contrasennaTemporal;
                datos.EsClaveTemporal = EsClaveTemporal;
                datos.ClaveVencimiento = ClaveVencimiento;
                rowsAffected = context.SaveChanges();
            }

            return (rowsAffected > 0 ? true : false);
            } catch { return false; }
        }
    }
}
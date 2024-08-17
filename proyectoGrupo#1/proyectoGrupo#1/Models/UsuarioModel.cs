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
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                rowsAffected = context.RegistrarUsuario(user.Cedula, user.Nombre, user.Correo, user.Contrasenna);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public IniciarSesion_Result IniciarSesion(Usuario user)
        {
            using (var context = new proyectoEntities())
            {
                return context.IniciarSesion(user.Correo, user.Contrasenna).FirstOrDefault();
            }
        }

        public List<tUsuario> ConsultarUsuarios()
        {
            using (var context = new proyectoEntities())
            {
                int idSesion = int.Parse(HttpContext.Current.Session["idUsuario"].ToString());

                return (from x in context.tUsuario
                        where x.id != idSesion
                        select x).ToList();
            }
        }

        public tUsuario ConsultarUsuario(int id)
        {
            using (var context = new proyectoEntities())
            {
                return (from x in context.tUsuario
                        where x.id == id
                        select x).FirstOrDefault();
            }
        }
        public bool CambiarEstadoUsuario(Usuario user)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                rowsAffected = context.CambiarEstadoUsuario(user.id);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public bool ActualizarUsuario(Usuario user)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                rowsAffected = context.ActualizarUsuario(user.Cedula, user.Nombre, user.Correo, user.idRol, user.id);
            }

            return (rowsAffected > 0 ? true : false);
        }

    }
}
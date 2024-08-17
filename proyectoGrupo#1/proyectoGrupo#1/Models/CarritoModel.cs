using proyectoGrupo_1.BaseDatos;
using proyectoGrupo_1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoGrupo_1.Models
{
    public class CarritoModel
    {
        public bool RegistrarCarrito(int idProducto, int Cantidades)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                int id = int.Parse(HttpContext.Current.Session["idUsuario"].ToString());
                rowsAffected = context.RegistrarCarrito(id, idProducto, Cantidades);
            }

            return (rowsAffected > 0 ? true : false);
        }
        
        public List<ConsultarCarrrito_Result> ConsultarCarrito()
        {
            using (var context = new proyectoEntities())
            {
                int id = int.Parse(HttpContext.Current.Session["idUsuario"].ToString());
                return context.ConsultarCarrrito(id).ToList();
            }

        }
    }
}
using proyectoGrupo_1.BaseDatos;
using proyectoGrupo_1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoGrupo_1.Models
{
    public class ProductoModel
    {
        public bool RegistrarProducto(Producto prod)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                rowsAffected = context.RegistrarProducto(prod.Nombre, prod.Precio, prod.Cantidad, prod.idCategoria, prod.Imagen);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public List<tProducto> VerProductos()
        {
            using (var context = new proyectoEntities())
            {

                return (from x in context.tProducto
                        select x).ToList();
            }
        }

        public List<tProducto> VerCelulares()
        {
            using (var context = new proyectoEntities())
            {               

                return (from x in context.tProducto
                        where x.idCategoria == 1
                        select x).ToList();
            }
        }
        public List<tProducto> VerAccesorios()
        {
            using (var context = new proyectoEntities())
            {

                return (from x in context.tProducto
                        where x.idCategoria == 3
                        select x).ToList();
            }
        }

        public List<tProducto> VerComputadoras()
        {
            using (var context = new proyectoEntities())
            {

                return (from x in context.tProducto
                        where x.idCategoria == 4
                        select x).ToList();
            }
        }

        public tProducto ConsultarProducto(int id)
        {
            using (var context = new proyectoEntities())
            {
                return (from x in context.tProducto
                        where x.id == id
                        select x).FirstOrDefault();
            }
        }

        public bool EditarProducto(Producto prod)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                rowsAffected = context.EditarProducto(prod.id, prod.Nombre, prod.Precio, prod.Cantidad, prod.idCategoria,prod.Imagen);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public bool EliminarProducto(Producto prod)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                rowsAffected = context.EliminarProducto(prod.id);
            }

            return (rowsAffected > 0 ? true : false);
        }

    }
}
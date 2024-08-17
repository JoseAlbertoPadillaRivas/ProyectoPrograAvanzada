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
        CarritoModel carritoM = new CarritoModel();

        public bool RegistrarProducto(Producto prod)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                rowsAffected = context.RegistrarProducto(prod.Descripcion, prod.Precio, prod.Cantidad, prod.idCategoria, prod.Imagen);
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
                        where x.idCategoria == 2
                        select x).ToList();
            }
        }

        public List<tProducto> VerComputadoras()
        {
            using (var context = new proyectoEntities())
            {

                return (from x in context.tProducto
                        where x.idCategoria == 3
                        select x).ToList();
            }
        }

        public tProducto ConsultarProducto(int idProducto)
        {
            using (var context = new proyectoEntities())
            {
                return (from x in context.tProducto
                        where x.idProducto == idProducto
                        select x).FirstOrDefault();
            }
        }

        public bool EditarProducto(Producto prod)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                rowsAffected = context.EditarProducto(prod.idProducto, prod.Descripcion, prod.Precio, prod.Cantidad, prod.idCategoria,prod.Imagen);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public bool EliminarProducto(Producto prod)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities())
            {
                rowsAffected = context.EliminarProducto(prod.idProducto);
            }

            return (rowsAffected > 0 ? true : false);
        }

    }
}
using proyectoGrupo_1.BaseDatos;
using proyectoGrupo_1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoGrupo_1.Models
{
    public class CategoriaModel
    {
        public List<tCategoria> ConsultarCategorias()
        {
            using (var context = new proyectoEntities1())
            {
                return (from x in context.tCategoria
                        select x).ToList();
            }
        }

        public bool RegistrarCategoria(Categoria cat)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.NuevaCategoria(cat.Nombre);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public tCategoria ConsultarCategoria(int id)
        {
            using (var context = new proyectoEntities1())
            {
                return (from x in context.tCategoria
                        where x.idCategoria == id
                        select x).FirstOrDefault();
            }
        }

        public bool EditarCategoria(Categoria cat)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.EditarCategoria(cat.idCategoria, cat.Nombre);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public bool EliminarCategoria(Categoria cat)
        {
            var rowsAffected = 0;

            using (var context = new proyectoEntities1())
            {
                rowsAffected = context.EliminarCategoria(cat.idCategoria);
            }

            return (rowsAffected > 0 ? true : false);
        }

    }
}
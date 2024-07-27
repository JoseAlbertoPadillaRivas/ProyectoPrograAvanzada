using proyectoGrupo_1.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoGrupo_1.Models
{
    public class CategoriaModel
    {
        public List<tCategoria> ConsultarCat()
        {
            using (var context = new proyectoEntities())
            {
                return (from x in context.tCategoria
                        select x).ToList();
            }
        }
    }
}
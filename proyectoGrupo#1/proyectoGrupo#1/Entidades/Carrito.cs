using proyectoGrupo_1.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoGrupo_1.Entidades
{
    public class Carrito
    {
        public int idProducto { get; set; }
        public List<ConsultarCarrrito_Result> DatosCarrito { get; set; }
    }
}
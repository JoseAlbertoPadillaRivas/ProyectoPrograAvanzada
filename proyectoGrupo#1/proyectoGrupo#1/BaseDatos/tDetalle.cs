//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyectoGrupo_1.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class tDetalle
    {
        public int idDetalle { get; set; }
        public int idMaestro { get; set; }
        public int idProducto { get; set; }
        public int cantidades { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
    }
}

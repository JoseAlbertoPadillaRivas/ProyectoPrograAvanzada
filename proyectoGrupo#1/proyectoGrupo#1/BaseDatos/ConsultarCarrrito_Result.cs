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
    
    public partial class ConsultarCarrrito_Result
    {
        public int idCarrito { get; set; }
        public int id { get; set; }
        public string Nombre { get; set; }
        public int idProducto { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public Nullable<int> SubTotal { get; set; }
        public Nullable<decimal> Impuesto { get; set; }
        public Nullable<decimal> Total { get; set; }
        public int Cantidades { get; set; }
        public System.DateTime Fecha { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using proyectoGrupo_1.BaseDatos;


namespace proyectoGrupo_1.Entidades
{
    public class Seguimiento
    {
        public int idUsuario { get; set; }
        public int idSeguimiento { get; set; }
        public string nombreProducto { get; set; }
        public bool Estado { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaSalida { get; set; }

        public List<ConsultarMiSeguimiento_Result> DatosSeguimiento { get; set; }
    }
}
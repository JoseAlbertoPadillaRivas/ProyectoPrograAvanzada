
namespace proyectoGrupo_1.Entidades
{
    public class Usuario
    {
        public int id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public bool Estado { get; set; }
        public int idRol { get; set; }

    }
}
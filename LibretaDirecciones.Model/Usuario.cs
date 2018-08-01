using System;

namespace LibretaDirecciones.Model
{
    public class Usuario : BaseObject
    {
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public bool Activo { get; set; }
        public string Password { get; set; }
    }
}

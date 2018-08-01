using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibretaDirecciones.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public bool Activo { get; set; }
    }
}

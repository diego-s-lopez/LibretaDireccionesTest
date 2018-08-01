using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibretaDirecciones.Bussiness;
using LibretaDirecciones.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibretaDirecciones.Controllers
{
    public class UsuariosController : Controller
    {
        public IActionResult Index()
        {
            var resp = new UsuariosViewModel();
            resp.Usuarios = _service.ListarUsuarios().Select(x =>
                    new UsuarioViewModel
 {
                        Id = x.Id,
                        Activo = x.Activo,
                        NombreUsuario = x.NombreUsuario,
                        Nombre = x.Nombre
                    })
                .ToList();

            return View(resp);
        }

        [HttpPost]
        public IActionResult ChangeActiveUser(int id, bool activo)
        {
            try
            {
                _service.CambiarEstado(id, activo);
                return Json(new JsonResponseBase<string>(true, "Se cambio estado correctamente"));
            }
            catch (Exception e)
            {
                return Json(new JsonResponseBase<string>(false, e.Message));
            }
        }

        public UsuariosController(UsuarioService service)
        {
            _service = service;
        }

        private readonly UsuarioService _service;
    }
}
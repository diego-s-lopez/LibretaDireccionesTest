using System;
using System.Collections.Generic;
using LibretaDirecciones.DataAccess;
using LibretaDirecciones.Model;

namespace LibretaDirecciones.Bussiness
{
    public class UsuarioService
    {
        public Usuario CreateUsuario(string nombre, string nombreUsuario)
        {
            var user = new Usuario
            {
                Nombre = nombre,
                NombreUsuario = nombreUsuario
            };

            _repository.Create(user);

            return user;
        }

        public void SetPassword(string nombreUsuario, string password, string repeatPassword)
        {
            if (password != repeatPassword)
                return;

            var user = _repository.GetById(nombreUsuario);
            if (user != null)
                user.Password = password;
        }

        public void CambiarEstado(int id, bool activo)
        {
            var user = _repository.GetById(id);
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.Password))
                {
                    //Ex informando que debe setear el pass
                }
                else
                    user.Activo = activo;

                _repository.Update(user);
            }
        }
        public void BorrarUsuario(int id)
        {
            _repository.DeleteById(id);
        }

        public ICollection<Usuario> ListarUsuarios() => _repository.GetAll();
        public ICollection<Usuario> ListarUsuarios(int page = 0, int cant = 10) => _repository.GetAll(page, cant);

        public Usuario GetUsuarioById(int idUsuario) => _repository.GetById(idUsuario);

        private void InitTestData()
        {
            for (int i = 0; i < 53; i++)
            {
                _repository.Create(new Usuario
                {
                    Nombre = $"Nombre de Test {i}",
                    NombreUsuario = $"NombreUsuario{i}",
                    Password = $"SoyUnaClave{i}",
                    Activo = i % 4 != 0
                });
            }
        }

        public UsuarioService(IRepository<Usuario> repository)
        {
            _repository = repository;

            InitTestData();
        }

        private readonly IRepository<Usuario> _repository;
    }
}

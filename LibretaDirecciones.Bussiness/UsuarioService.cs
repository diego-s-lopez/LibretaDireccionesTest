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

        public void ActivarUsuario(string nombreUsuario)
        {
            var user = _repository.GetById(nombreUsuario);
            if (user != null)
            {
                if (string.IsNullOrEmpty(user.Password))
                {
                    //Ex informando que debe setear el pass
                }
                else
                    user.Activo = true;

                _repository.Update(user);
            }
        }

        public ICollection<Usuario> ListarUsuarios() => _repository.GetAll();

        private void InitTestData()
        {
            _repository.Create(new Usuario{ Nombre = "Diego", NombreUsuario = "DiegoNombreUsuario",Password = "SoyUnaClave", Activo = true});
            _repository.Create(new Usuario{ Nombre = "Carlos", NombreUsuario = "CarlosNombreUsuario",Password = "SoyUnaClave"});
            _repository.Create(new Usuario{ Nombre = "Pepe", NombreUsuario = "PepeNombreUsuario", Password = "SoyUnaClave", Activo = true});
        }

        public UsuarioService(IRepository<Usuario> repository)
        {
            _repository = repository;

            InitTestData();
        }

        private readonly IRepository<Usuario> _repository;
    }
}

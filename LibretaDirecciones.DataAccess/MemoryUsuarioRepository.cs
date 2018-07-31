using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibretaDirecciones.Model;

namespace LibretaDirecciones.DataAccess
{
    public class MemoryUsuarioRepository : IRepository<Usuario>
    {
        public Usuario GetById(int id)
        {
            lock (_data)
                return _data.FirstOrDefault(x => x.Id == id);
        }

        public Usuario GetById(string id)
        {
            lock (_data)
                return _data.FirstOrDefault(x => x.NombreUsuario == id);
        }

        public ICollection<Usuario> GetAll()
        {
            lock (_data)
                return _data;
        }

        public void Create(Usuario obj)
        {
            lock (_data)
            {
                if (obj.Id==0)
                    obj.Id = _data.Count > 0 ? _data.Max(x => x.Id) + 1 : 1;

                _data.Add(obj);
            }
        }

        public void Update(Usuario obj)
        {
            lock (_data)
            {
                _data.Remove(GetById(obj.NombreUsuario));
                Create(obj);
            }
        }

        public void DeleteById(int id)
        {
            lock (_data)
            {
                _data.RemoveAll(x => x.Id == id);
            }
        }

        public void DeleteById(string id)
        {
            lock (_data)
            {
                _data.RemoveAll(x => x.NombreUsuario == id);
            }
        }

        private readonly List<Usuario> _data = new List<Usuario>();
    }
}

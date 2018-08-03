using System;
using System.Collections.Generic;

namespace LibretaDirecciones.DataAccess
{
    public interface IRepository <T>
    {
        T GetById(int id);
        T GetById(string id);
        ICollection<T> GetAll();
        ICollection<T> GetAll(int page, int cant);
        void Create(T obj);
        void Update(T obj);
        void DeleteById(int id);
        void DeleteById(string id);
    }
}

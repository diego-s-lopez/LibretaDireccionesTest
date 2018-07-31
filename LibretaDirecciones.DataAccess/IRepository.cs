using System;
using System.Collections.Generic;

namespace LibretaDirecciones.DataAccess
{
    public interface IRepository <T>
    {
        T GetById(int id);
        T GetById(string id);
        ICollection<T> GetAll();
        void Create(T obj);
        void Update(T obj);
        void DeleteById(int id);
        void DeleteById(string id);
    }
}

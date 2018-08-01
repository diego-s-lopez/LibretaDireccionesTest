using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibretaDirecciones.Models
{
    public class JsonResponseBase<T>
    {
        public bool Success { get; }
        public T Data { get; }

        public JsonResponseBase(bool success, T data)
        {
            Success = success;
            Data = data;
        }
    }
}

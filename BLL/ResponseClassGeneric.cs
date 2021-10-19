using System.Collections.Generic;

namespace BLL
{
    public class ResponseClassGeneric<T>
    {
        public ResponseClassGeneric(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }  

        public ResponseClassGeneric(T objeto)
        {
            Error = false;
            Object = objeto;
        }
        public ResponseClassGeneric(List<T> objects)
        {
            Error = false;
            Objects = objects;
        }

        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public T Object { get; set; }
        public List<T> Objects { get; set; }
    }
}
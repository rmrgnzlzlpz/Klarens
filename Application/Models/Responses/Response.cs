using Application.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Models
{
    public class Response<T> : IResponse<T> where T : class
    {
        public string Mensaje { get; private set; }
        public IList<T> Entidades { get; private set; }

        public Response(string mensaje, IList<T> entidad)
        {
            Mensaje = mensaje;
            Entidades = entidad;
        }

        public Response(string mensaje, T entidad)
        {
            Mensaje = mensaje;
            Entidades = new List<T> { entidad };
        }

        public Response(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}

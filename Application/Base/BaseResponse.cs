using System.Collections.Generic;

namespace Application.Base
{
    public abstract class BaseResponse
    {
    }

    public abstract class Response<T> : BaseResponse, IResponse<T> where T : class
    {
        public string Mensaje { get; private set; }
        public List<T> Entidades { get; private set; }

        public Response(string mensaje, List<T> entidades)
        {
            Mensaje = mensaje;
            Entidades = entidades;
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
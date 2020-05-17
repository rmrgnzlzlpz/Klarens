using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Base
{
    public interface IResponse<T>
    {
        string Mensaje { get;}
        IList<T> Entidades { get; }
    }
}

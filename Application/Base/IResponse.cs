using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Base
{
    public interface IResponse<T> where T : class
    {
        string Message { get; set; }
        T Entity { get; set; }
    }
}

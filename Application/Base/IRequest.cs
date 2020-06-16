﻿using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Base
{
    public interface IRequest<T>
    {
        T ToEntity();
    }
}

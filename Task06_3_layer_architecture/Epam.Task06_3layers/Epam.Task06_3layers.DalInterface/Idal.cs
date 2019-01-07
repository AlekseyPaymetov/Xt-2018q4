﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task06_3layers.DalInterface
{
    public interface Idal<T>
    {
        bool Add(T someObject);

        bool Delete(int id);

        IEnumerable<T> GetAll();
    }
}

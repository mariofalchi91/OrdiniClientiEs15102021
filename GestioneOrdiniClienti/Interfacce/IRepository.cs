using System;
using System.Collections.Generic;

namespace Core.Interfacce
{
    public interface IRepository<T>
    {
        List<T> Fetch(Func<T, bool> filter = null);
        T GetById(int id);
        bool Add(T newItem);
        bool Edit(T item);
        bool DeleteById(int id);
    }
}

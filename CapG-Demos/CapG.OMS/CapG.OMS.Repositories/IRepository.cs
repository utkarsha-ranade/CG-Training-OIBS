using System;
using System.Collections.Generic;

namespace CapG.OMS.Repositories
{
    public interface IRepository<T>
    {
        T Get(object key);
        IEnumerable<T> Get();
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(object key);
    }
}

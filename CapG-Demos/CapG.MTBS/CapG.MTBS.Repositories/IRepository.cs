using System;
using System.Collections.Generic;
using System.Text;

namespace CapG.MTBS.Repositories
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

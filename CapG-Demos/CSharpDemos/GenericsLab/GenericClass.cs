using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsLab
{
    internal class GenericClass<T>
    {
        T data;

        public void Add(T item)
        {
            data = item;
        }

        public void Method1<U>(U item)
        { }
    }
}

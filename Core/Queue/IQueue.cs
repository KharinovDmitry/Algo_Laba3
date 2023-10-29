using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IQueue<T>
    {
        public bool isEmpty();

        public void Enqueue(T item);
        public T GetHead();

        public T Dequeue();

        public string ToString();
        public void Clear();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Queue<T> : IEnumerable<T>
    {
        private LinkedList<T> list = new LinkedList<T>();

        public uint Length => list.Length;
        public bool isEmpty => list.Length == 0;


        public void Enqueue(T item) 
        {
            list.Add(item);
        }

        public T Dequeue()
        {
            var res = list[0];
            list.Remove(0);
            return res;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.Append(item).Append(" ");
            }
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

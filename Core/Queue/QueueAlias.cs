using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class QueueAlias<T> : IEnumerable<T>, IQueue<T>
    {
        private System.Collections.Generic.Queue<T> queue = new System.Collections.Generic.Queue<T>();

        public int Length => queue.Count;
        public bool isEmpty() => Length == 0;

        public T GetHead()
        {
            return queue.First();
        }

        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }

        public T Dequeue()
        {
            return queue.Dequeue();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in queue)
            {
                sb.Append(item).Append(" ");
            }
            return sb.ToString();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            queue.Clear();
        }
    }
}

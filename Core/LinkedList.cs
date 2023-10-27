using System.Collections;

namespace Algo_Laba3
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T>? head;
        private Node<T>? tail;

        public uint Length { get; private set; } = 0;

        public void Add(T item)
        {
            if (head == null)
            {
                tail = head = new Node<T>(item, null, null);
            }
            else
            {
                var newNode = new Node<T>(item, tail, null);
                tail.Next = newNode;
                tail = newNode;
            }
            Length++;
        }
        
        public T this[int index]
        {
            get => getNode(index).Value;
            set => getNode(index).Value = value;
        }


        public void Remove(int index)
        {
            var item = getNode(index);
            Length--;
            if (item.Prev == null)
            {
                head = item.Next;
                return;
            }
            if(item.Next == null)
            {
                item.Prev.Next = null;
                tail = item.Prev;
                return;
            }
            item.Prev.Next = item.Next;
        }
        
        private Node<T> getNode(int index)
        {
            if(index > Length)
                throw new IndexOutOfRangeException();

            Node<T> res;
            if(index == 0 || Length / index >= 2)
            {
                res = head;
                for (int i = 0; i < index; i++)
                {
                    res = res.Next;
                }
                return res;
            }

            res = tail;
            for (int i = 0; i < Length - index - 1; i++)
            {
                res = res.Prev;
            }
            return res;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    internal class Node<T>
    {
        public Node<T>? Prev;
        public Node<T>? Next;
        public T? Value;

        public Node(T value, Node<T> prev, Node<T> next)
        {
            Prev = prev;
            Next = next;
            Value = value;
        }
    }
}

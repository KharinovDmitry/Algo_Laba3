using System.Collections;

namespace Core
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public Node<T>? Head { get; set; }
        public Node<T>? Tail { get; set; }

        public uint Length { get; private set; } = 0;

        public void Add(T item)
        {
            if (Head == null)
            {
                Tail = Head = new Node<T>(item, null, null);
            }
            else
            {
                var newNode = new Node<T>(item, Tail, null);
                Tail.Next = newNode;
                Tail = newNode;
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

                Head = item.Next;
                if(item.Next != null)
                {
                    item.Next.Prev = null;
                }
                return;
            }
            if(item.Next == null)
            {
                item.Prev.Next = null;
                Tail = item.Prev;
                return;
            }
            item.Prev.Next = item.Next;
        }

        public void Clear()
        {
            Head = null;
            Length = 0;
        }
        
        private Node<T> getNode(int index)
        {
            if(index > Length)
                throw new IndexOutOfRangeException();

            Node<T> res;
            if(index == 0 || Length / index >= 2)
            {
                res = Head;
                for (int i = 0; i < index; i++)
                {
                    res = res.Next;
                }
                return res;
            }

            res = Tail;
            for (int i = 0; i < Length - index - 1; i++)
            {
                res = res.Prev;
            }
            return res;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
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

    public class Node<T>
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

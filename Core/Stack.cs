using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Core
{
    public class Stack<T>
    {
        private LinkedList<T> _list = new LinkedList<T>();

        public void Push(T element)
        {
            _list.Add(element);
        }

        public object Pop()
        {
            T data = _list[(int)_list.Length - 1];
            _list.Remove((int)_list.Length - 1);
            return data;
        }

        public bool IsEmpty()
        {
            return _list.Length == 0;
        }

        public void Print()
        {
            string column = "";
            for (int i = 0; i < _list.Length; i++)
            {
                column = _list[i] + "\n" + column;
            }
            Console.WriteLine(column);
        }
    }
}

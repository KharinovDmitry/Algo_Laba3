using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core
{
    public static class LinkedListExtension
    {
        public static void Reverse<T>(this LinkedList<T> list)
        {
            Node<T>? current = list.Head;

            while (current != null)
            {
                Node<T>? temp = current.Next;
                current.Next = current.Prev;
                current.Prev = temp;
                current = temp;
            }

            Node<T>? tempTail = list.Tail;
            list.Tail = list.Head;
            list.Head = tempTail;
        }

        public static LinkedList<T> SwapFirstAndLast<T>(this LinkedList<T> list)
        {
            if (list.Length < 2)
            {
                return list;
            }

            Node<T>? head = list.Head;
            Node<T>? tail = list.Tail;

            LinkedList<T> result = new LinkedList<T> { tail.Value };

            for (int i = 1; i < list.Length - 1; i++)
            {
                result.Add(list[i]);
            }
            result.Add(head.Value);

            return result;
        }

        public static int GetCountOfDistinctIntegers<T>(this LinkedList<T> list)
        {
            HashSet<int> distinctSet = new HashSet<int>();

            foreach (var item in list)
            {
                if (item is int value)
                {
                    distinctSet.Add(value);
                }
            }

            return distinctSet.Count;
        }

        public static void RemoveAllDuplicates<T>(this LinkedList<T> list)
        {
            HashSet<T> hashSet = new HashSet<T>();

            Node<T>? head = list.Head;
            Node<T>? tail = list.Tail;

            while (head != null)
            {
                if (hashSet.Contains(head.Value))
                {
                    tail.Next = head.Next;

                    if (head.Next != null)
                    {
                        head.Next.Prev = tail;
                    }
                }
                else
                {
                    hashSet.Add(head.Value);
                    tail = head;
                }

                head = head.Next;
            }
        }

        public static LinkedList<T> InsertListAfterFirstOccurrence<T>(this LinkedList<T> list, T x)
        {
            LinkedList<T> result = new LinkedList<T>();
            Node<T>? current = list.Head;

            bool found = false;
            while (current != null)
            {
                result.Add(current.Value);

                if (!found && current.Value.Equals(x))
                {
                    Node<T>? xNode = list.Head;
                    found = true;

                    while (xNode != null)
                    {
                        result.Add(xNode.Value);
                        xNode = xNode.Next;
                    }
                }

                current = current.Next;
            }

            return result;
        }

        public static void InsertOrdered<T>(this LinkedList<T> list, T element) where T : IComparable<T>
        {
            Node<T>? current = list.Head;

            while (current != null)
            {
                if (current.Value.CompareTo(element) >= 0)
                {
                    Node<T> newNode = new Node<T>(element, current.Prev, current);

                    if (current.Prev == null)
                    {
                        list.Head = newNode;
                    }
                    else
                    {
                        current.Prev.Next = newNode;
                    }

                    current.Prev = newNode;

                    break;
                }

                if (current.Next == null)
                {
                    Node<T> newNode = new Node<T>(element, current, null);
                    current.Next = newNode;
                    list.Tail = newNode;

                    break;
                }

                current = current.Next;
            }
        }

        public static void RemoveAll<T>(this LinkedList<T> list, T element)
        {
            Node<T>? current = list.Head;

            while (current != null)
            {
                if (current.Value.Equals(element))
                {
                    Node<T> next = current.Next;
                    Node<T> prev = current.Prev;

                    if (prev == null)
                    {
                        list.Head = next;
                    }
                    else
                    {
                        prev.Next = next;
                    }

                    if (next == null)
                    {
                        list.Tail = prev;
                    }
                    else
                    {
                        current.Prev = prev;
                    }
                }

                current = current.Next;
            }
        }

        public static void InsertBeforeFirst<T>(this LinkedList<T> list, T existingItem, T newItem)
        {
            Node<T>? current = list.Head;

            while (current != null)
            {
                if (current.Value.Equals(existingItem))
                {
                    Node<T> newNode = new Node<T>(newItem, current.Prev, current);

                    if (current.Prev == null)
                    {
                        list.Head = newNode;
                    }
                    else
                    {
                        current.Prev.Next = newNode;
                    }

                    current.Prev = newNode;

                    break;
                }

                current = current.Next;
            }
        }

        public static void AppendList(this LinkedList<int> firstList, LinkedList<int> secondList)
        {
            foreach (int item in secondList)
            {
                firstList.Add(item);
            }
        }

        public static Tuple<LinkedList<T>, LinkedList<T>> SplitList<T>(this LinkedList<T> list, T value)
        {
            LinkedList<T> firstList = new LinkedList<T>();
            LinkedList<T> secondList = new LinkedList<T>();
            bool found = false;

            if (!list.Contains(value))
            {
                return Tuple.Create(firstList, secondList);
            }

            Node<T>? current = list.Head;

            while (current != null)
            {
                if (!found && current.Value.Equals(value))
                {
                    found = true;
                }

                if (found)
                {
                    secondList.Add(current.Value);
                }
                else
                {
                    firstList.Add(current.Value);
                }

                current = current.Next;
            }

            return Tuple.Create(firstList, secondList);
        }

        public static void DuplicateList<T>(this LinkedList<T> list)
        {
            uint maxIndex = list.Length - 1;
            for (int i = 0; i <= maxIndex; i++)
            {
                list.Add(list[i]);
            }
        }

        public static void SwapElements<T>(this LinkedList<T> list, int index1, int index2)
        {
            if (index1 >= list.Length || index2 >= list.Length)
            {
                throw new IndexOutOfRangeException();
            }

            if (index1 == index2)
            {
                return;
            }

            Node<T>? node1 = list.Head;
            for (int i = 0; i < index1; i++)
            {
                node1 = node1.Next;
            }

            Node<T>? node2 = list.Head;
            for (int i = 0; i < index2; i++)
            {
                node2 = node2.Next;
            }

            if (node1.Next == node2)
            {
                SwapAdjacentNodes(list, node1, node2);
            }
            else if (node2.Next == node1)
            {
                SwapAdjacentNodes(list, node2, node1);
            }
            else
            {
                SwapNonAdjacentNodes(list, node1, node2);
            }
        }

        private static void SwapAdjacentNodes<T>(LinkedList<T> list, Node<T> node1, Node<T> node2)
        {
            var beforeNode1 = node1.Prev;
            var afterNode2 = node2.Next;

            if (beforeNode1 != null)
            {
                beforeNode1.Next = node2;
            }
            else
            {
                list.Head = node2;
            }

            node2.Prev = beforeNode1;
            node2.Next = node1;
            node1.Prev = node2;
            node1.Next = afterNode2;

            if (afterNode2 != null)
            {
                afterNode2.Prev = node1;
            }
            else
            {
                list.Tail = node1;
            }
        }

        private static void SwapNonAdjacentNodes<T>(LinkedList<T> list, Node<T> node1, Node<T> node2)
        {
            var beforeNode1 = node1.Prev;
            var afterNode1 = node1.Next;
            var beforeNode2 = node2.Prev;
            var afterNode2 = node2.Next;

            if (beforeNode1 != null)
            {
                beforeNode1.Next = node2;
            }
            else
            {
                list.Head = node2;
            }

            node2.Prev = beforeNode1;
            node2.Next = afterNode1;

            if (afterNode1 != null)
            {
                afterNode1.Prev = node2;
            }

            if (beforeNode2 != null)
            {
                beforeNode2.Next = node1;
            }
            else
            {
                list.Head = node1;
            }

            node1.Prev = beforeNode2;
            node1.Next = afterNode2;

            if (afterNode2 != null)
            {
                afterNode2.Prev = node1;
            }

            if (node1 == list.Head)
            {
                list.Head = node2;
            }

            if (node2 == list.Tail)
            {
                list.Tail = node1;
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private class Node
        {
            public T Data;
            public Node Next;
            public Node Previous;

            public Node(T data)
            {
                Data = data;
                Next = null;
                Previous = null;
            }
        }

        private Node first;
        private Node last;
        private int count;

        public int Length => count;

        public void Add(T e)
        {
            Node newNode = new Node(e);
            if (first == null)
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                last.Next = newNode;
                newNode.Previous = last;
                last = newNode;
            }
            count++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(nameof(index));

            Node newNode = new Node(e);
            if (index == 0)
            {
                if (first == null)
                {
                    first = newNode;
                    last = newNode;
                }
                else
                {
                    newNode.Next = first;
                    first.Previous = newNode;
                    first = newNode;
                }
            }
            else if (index == count)
            {
                last.Next = newNode;
                newNode.Previous = last;
                last = newNode;
            }
            else
            {
                Node current = first;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current;
                newNode.Previous = current.Previous;
                current.Previous.Next = newNode;
                current.Previous = newNode;
            }
            count++;
        }

        public T ElementAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException(nameof(index));

            Node current = first;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = first;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Remove(T item)
        {
            Node current = first;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        first = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        last = current.Previous;
                    }

                    count--;
                    return;
                }
                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException(nameof(index));

            Node current = first;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current.Previous != null)
            {
                current.Previous.Next = current.Next;
            }
            else
            {
                first = current.Next;
            }

            if (current.Next != null)
            {
                current.Next.Previous = current.Previous;
            }
            else
            {
                last = current.Previous;
            }

            count--;
            return current.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

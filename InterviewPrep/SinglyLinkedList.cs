using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPrep
{
    internal class SinglyLinkedList<T> : ICollection<T>
    {
        private SinglyLinkedListNode<T>? head = null;
        public SinglyLinkedList() { }

        int ICollection<T>.Count => throw new NotImplementedException();

        bool ICollection<T>.IsReadOnly => throw new NotImplementedException();

        public void Add(T value)
        {
            if (head == null)
            {
                head = new SinglyLinkedListNode<T>(value, null);
            } else
            {
                SinglyLinkedListNode<T> node = head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = new SinglyLinkedListNode<T>(value, null);
            }
        }

        /*public void AddAfter(T , T value)
        {
            if (head == null)
            {
                head = new SinglyLinkedListNode<T>(value, null);
            } else
            {
                SinglyLinkedListNode<T> node = head;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = new SinglyLinkedListNode<T>(value, null);
            }
        }*/

        public SinglyLinkedListNode<T> First()
        {
            return head;
        }

        public SinglyLinkedListNode<T> Last()
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Contains(T item)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }
    }

    internal class SinglyLinkedListNode<T>
    {
        public T Value { get; set; }
        public SinglyLinkedListNode<T>? Next { get; set; }

        public SinglyLinkedListNode(T value, SinglyLinkedListNode<T> next)
        {
            this.Value = value;
            this.Next = next;
        }
    }

}

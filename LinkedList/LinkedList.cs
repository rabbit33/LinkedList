using System;

namespace LinkedList
{
    public class LinkedList<T> where T : IComparable<T>, IComparable
    {
        public Node<T> Head { get; private set; }

        public LinkedList()
        {
            Head = null;
        }

        public LinkedList(T[] array)
        {
            //head = null;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    InsertLast(array[i]);
            //}

            Head = null;
            for (int i = array.Length - 1; i >= 0; i--)
            {
                InsertFirst(array[i]);
            }
        }

        public void InsertFirst(T data)
        {
            Node<T> temp = new Node<T> { Data = data, Next = Head };
            Head = temp;
        }

        public void InsertLast(T data)
        {
            Node<T> temp = new Node<T> { Data = data, Next = null };

            if (Head == null)
            {
                Head = temp;
                return;
            }

            Node<T> pointer = Head;
            while (pointer.Next != null)
            {
                pointer = pointer.Next;
            }
            pointer.Next = temp;
        }

        public void InsertAfter(Node<T> node, T data)
        {
            if (node == null)
            {
                throw new Exception("Previous node cannot be null");
            }

            Node<T> newNode = new Node<T>();
            newNode.Data = data;
            newNode.Next = node.Next;
            node.Next = newNode;
        }

        public void DeleteFirst()
        {
            Head = Head.Next;
        }

        public void DeleteLast()
        {
            //if there are no nodes, nothing to do
            if (IsEmpty())
            {
                return;
            }

            //if there is only one node, delete it;
            if (Head.Next == null)
            {
                Head = null;
                return;
            }

            Node<T> pointer = Head;
            while (pointer.Next.Next != null)
            {
                pointer = pointer.Next;
            }
            pointer.Next = null;
        }

        //todo: fix this
        public void DeleteAt(int index)
        {
            if (index == 0)
            {
                DeleteFirst();
                return;
            }
            if (index == Count() - 1)
            {
                DeleteLast();
                return;
            }

            if (index >= Count())
            {
                throw new IndexOutOfRangeException($"Index = {index}");
            }

            Node<T> pointer = Head;
            for (int i = 0; i < index - 1; i++)
            {
                pointer = pointer.Next;
            }

            pointer.Next = pointer.Next.Next;
            pointer = pointer.Next.Next;
        }

        public void DeleteKey(int key)
        {
            if (Head == null)
            {
                return;
            }

            //List has only one node and the node has that key.
            if (Head.Data.CompareTo(key) == 0 && Head.Next == null)
            {
                Head = null;
                return;
            }

            if (Head.Data.CompareTo(key) == 0)
            {
                Head = Head.Next;
                return;
            }

            Node<T> current = Head;
            Node<T> previous = null;

            while (current != null && current.Data.CompareTo(key) != 0)
            {
                previous = current;
                current = current.Next;
            }

            //Key was not found
            if (current == null)
            {
                Console.WriteLine("Key not found");
                return;
            }

            //Update link
            previous.Next = current.Next;
         }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public int Count()
        {
            if (IsEmpty())
            {
                return 0;
            }

            int count = 0;
            Node<T> pointer = Head;
            while (pointer != null)
            {
                count = count + 1;
                pointer = pointer.Next;
            }

            return count;
        }

        public int CountRec(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + CountRec(node.Next);
        }

        public bool IsEqualTo(LinkedList<T> other)
        {
            if (other.Count() != this.Count())
            {
                return false;
            }

            Node<T> pointerOther = other.Head;
            Node<T> pointerThis = this.Head;

            while (pointerOther != null && pointerThis != null)
            {
                if (pointerOther.Data.CompareTo(pointerThis.Data) != 0)
                {
                    return false;
                }
                pointerOther = pointerOther.Next;
                pointerThis = pointerThis.Next;
            }

            return true;
        }

        public void Display(Action<string> display)
        {
            Node<T> pointer = Head;
            if (Head == null)
            {
                display("List is empty.");
            }

            while (pointer != null)
            {
                display($"{pointer.Data} ");
                pointer = pointer.Next;
            }

            display("\n");
        }
    }
}

using LinkedList;
using System;

namespace LinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> displayAction = Console.Write;

            LinkedList<int> list = new LinkedList<int>();
            list.InsertLast(1);
            list.InsertLast(2);
            list.InsertLast(3);
            list.Display(displayAction);
            list.DeleteFirst();
            list.Display(displayAction);
            list.DeleteLast();
            list.Display(displayAction);
            list.DeleteLast();
            list.Display(displayAction);

            list = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5 });
            list.Display(displayAction);

            Node<int> firstNode = list.Head;
            list.InsertAfter(firstNode, 10);
            list.InsertAfter(firstNode, 15);
            list.InsertFirst(9);
            list.InsertLast(100);
            list.Display(displayAction);
            list.DeleteAt(7);
            list.Display(displayAction);

            Console.ReadLine();
        }
    }
}

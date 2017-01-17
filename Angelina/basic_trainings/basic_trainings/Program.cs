using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int[] array = new int[] { 6, 6, 99, 56, 58, 4, 3, 98, 5, 17, 45, 89 };
            //char[] array = new char[] { 'g', 'e', 'y', 'l', 'u', 'r', 'h', 'q', 'w' };
            Console.WriteLine("Initial array:");
            foreach (int value in array)
            {
                Console.Write("{0}  ", value);
            }
            Console.Write("\n");
            
            Console.WriteLine("\nPeople:");
            Human[] people =               
                {
                new Human("John", 61 ),
                new Human("Peter", 43 ),
                new Human("Kate", 45 ),
                new Human("Anna", 18 )
            };

            foreach(Human h in people)
            {
                h.Print();
            }
            Array.Sort(people);
            Console.WriteLine("\nPeople after sort:");

            foreach (Human h in people)
            {
                h.Print();
            }
            Console.WriteLine("\nBubble Sort:");
            BubbleSorter<int> bsort = new BubbleSorter<int>(array);
            bsort.Print();
            bsort.Sort();
            bsort.Print();

            Console.WriteLine("\nInsertion Sort:");
            InsertionSorter<int> insort = new InsertionSorter<int>(array);
            insort.Print();
            insort.Sort();
            insort.Print();                     
    

            //stack
            Console.WriteLine("\n\n STACK:\n");
            MyStack<int> mystack = new MyStack<int>(10);

            Console.WriteLine("Stack is empty: {0}", mystack.IsEmpty());
            mystack.Push(1);
            mystack.Push(2);
            mystack.Push(3);
            mystack.Push(4);
            mystack.Push(5);
            mystack.Push(6);
            mystack.Push(7);
            mystack.Push(8);
            mystack.Push(9);
            mystack.Push(10);
            mystack.Push(11);
            mystack.Push(12);
            mystack.Push(13);
            mystack.Print();
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Peek());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine("Stack is full: {0}", mystack.IsFull());
            Console.WriteLine("Stack is empty: {0}", mystack.IsEmpty());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            mystack.Push(55);
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());

            
            
            //queue
            Console.WriteLine("\n\n CIRCULAR QUEUE:\n");
            MyQueue<int> myqueue = new MyQueue<int>(10);

            Console.WriteLine("Queue is full: {0}", myqueue.IsFull());
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty());
            Console.WriteLine(myqueue.Dequeue());

            myqueue.Enqueue(1);
            myqueue.Enqueue(2);
            myqueue.Enqueue(3);
            myqueue.Enqueue(4);
            myqueue.Enqueue(5);
            myqueue.Enqueue(6);
            myqueue.Enqueue(7);
            myqueue.Enqueue(8);
            myqueue.Print();
            myqueue.Enqueue(9);
            myqueue.Enqueue(10);
            Console.WriteLine(myqueue.Dequeue());
            myqueue.Enqueue(11);
            myqueue.Enqueue(12);

            Console.WriteLine("Queue is full: {0}", myqueue.IsFull());
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine("Queue is full: {0}", myqueue.IsFull());
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine("Queue is full: {0}", myqueue.IsFull());
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty());         
            */

            /*
            //Dynamic array

            Console.WriteLine("\n\n DYNAMIC ARRAY:\n");

            DynamicArray <int> list= new DynamicArray<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(4);
            Console.WriteLine("Capacity: "+list.Capacity);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            list.Add(4);
            list.Print();
            list.Remove(0);       
            list.Print();
            list.Insert(12, 2);
            list.Print();
            Console.WriteLine("Capacity: " + list.Capacity);
            */
            /*
            //dynamic stack
            Console.WriteLine("\n\n DYNAMIC STACK:\n");
            DynamicStack<int> mystack = new DynamicStack<int>(10);

            Console.WriteLine("Stack is empty: {0}", mystack.IsEmpty());

          
            mystack.Push(1);           
            mystack.Push(2);
            mystack.Push(3);
            mystack.Push(4);
            
            mystack.Push(5);
            mystack.Push(6);
            mystack.Push(7);
            mystack.Push(8);
            mystack.Push(9);
            mystack.Push(10);
            mystack.Push(11);
            mystack.Push(12);
            mystack.Push(13);
            

            
            mystack.Print();
            
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Peek());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine("Stack is full: {0}", mystack.IsFull());
            Console.WriteLine("Stack is empty: {0}", mystack.IsEmpty());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            mystack.Push(55);
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Pop());
            */


            /*
            //dynamic queue
            Console.WriteLine("\n\n DYNAMIC QUEUE:\n");
            DynamicQueue<int> myqueue = new DynamicQueue<int>(10);

            Console.WriteLine("Queue is full: {0}", myqueue.IsFull());
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty());
           // Console.WriteLine(myqueue.Dequeue());

            myqueue.Enqueue(1);
            myqueue.Enqueue(2);
            myqueue.Enqueue(3);
            myqueue.Enqueue(4);
            myqueue.Enqueue(5);
            myqueue.Enqueue(6);
            myqueue.Enqueue(7);
            myqueue.Enqueue(8);
            myqueue.Print();
            myqueue.Enqueue(9);
            myqueue.Enqueue(10);
            myqueue.Print();
            Console.WriteLine(myqueue.Dequeue());
            myqueue.Print();
            myqueue.Enqueue(11);
            myqueue.Enqueue(12);

            Console.WriteLine("Queue is full: {0}", myqueue.IsFull());
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine("Queue is full: {0}", myqueue.IsFull());
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine("Queue is full: {0}", myqueue.IsFull());
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
          */

            //linked list
            Console.WriteLine("\n\n LINKED LIST:\n");

            MyLinkedList<int> linkedList = new MyLinkedList<int>();

            Console.WriteLine("Count: " + linkedList.Count);

            linkedList.Remove(23);
            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            linkedList.Print();

            linkedList.Add(1);
            linkedList.AddFirst(0);
            linkedList.AddLast(2);
            linkedList.Print();

            linkedList.Add(3);
            linkedList.Add(4);
            linkedList.Add(5);
            linkedList.Add(6);
            linkedList.Print();

            linkedList.Remove(23);
            linkedList.Remove(4);
            linkedList.Remove(3);
            linkedList.Remove(2);
            linkedList.Print();

            Console.WriteLine("Count: " + linkedList.Count);
            // Console.WriteLine(linkedList[0]);

            linkedList.AddAfter(2, 22);
            linkedList.AddAfter(1, 11);
            linkedList.AddBefore(5, 55);
            linkedList.AddBefore(0, 100);
            linkedList.AddAfter(6, 66);

            linkedList.Print();


            Console.ReadLine();
        }
    }
}

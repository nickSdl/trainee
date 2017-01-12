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
            
            int[] array = new int[] { 6, 6, 99, 56, 58, 4, 3, 98, 5, 17, 45, 89 };

            Console.WriteLine("Initial array:");
            foreach (int value in array)
            {
                Console.Write("{0}  ", value);
            }
            Console.Write("\n");

            Console.WriteLine("\nBubble Sort:");
            BubbleSorter bsort = new BubbleSorter(array);
            bsort.Print();
            bsort.Sort();
            bsort.Print();

            Console.WriteLine("\nInsertion Sort:");
            InsertionSorter insort = new InsertionSorter(array);
            insort.Print();
            insort.Sort();
            insort.Print();                     
    

            //stack
            Console.WriteLine("\n\n STACK:\n");
            MyStack mystack = new MyStack(10);

            Console.WriteLine("Stack is empty: {0}", mystack.IsEmpty);
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
            Console.WriteLine(mystack.Pop());
            Console.WriteLine(mystack.Peek());
            Console.WriteLine(mystack.Pop());
            Console.WriteLine("Stack is full: {0}", mystack.IsFull);
            Console.WriteLine("Stack is empty: {0}", mystack.IsEmpty);
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
            MyQueue myqueue = new MyQueue(10);

            Console.WriteLine("Queue is full: {0}", myqueue.IsFull);
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty);
            Console.WriteLine(myqueue.Dequeue());

            myqueue.Enqueue(1);
            myqueue.Enqueue(2);
            myqueue.Enqueue(3);
            myqueue.Enqueue(4);
            myqueue.Enqueue(5);
            myqueue.Enqueue(6);
            myqueue.Enqueue(7);
            myqueue.Enqueue(8);
            myqueue.Enqueue(9);
            myqueue.Enqueue(10);
            Console.WriteLine(myqueue.Dequeue());
            myqueue.Enqueue(11);
            myqueue.Enqueue(12);

            Console.WriteLine("Queue is full: {0}", myqueue.IsFull);
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty);
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine("Queue is full: {0}", myqueue.IsFull);
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty);
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine(myqueue.Dequeue());
            Console.WriteLine("Queue is full: {0}", myqueue.IsFull);
            Console.WriteLine("Queue is empty: {0}", myqueue.IsEmpty);         
            

            Console.ReadLine();
        }
    }
}

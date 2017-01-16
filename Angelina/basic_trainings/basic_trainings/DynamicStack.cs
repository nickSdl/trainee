using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class DynamicStack<T> : IBuffer<T> where T : IComparable
    {
        private DynamicArray<T> stack;

        private int Size;
        private int Counter;

        public DynamicStack(int Size)
        {
            stack = new DynamicArray<T>();
            this.Size = Size;
            this.Counter = 0;
        }

        public bool IsEmpty()
        {
            
            if (Counter == 0)
            {
                return true;
            }
            else
            {
                return false;
            }                                 
        }

        public bool IsFull()
        {
            if (Counter < Size)
            {
                return false;
            }
            else 
            {
                return true;
            }           
        }

        public void Print()
        {
            Console.WriteLine("\nStack:");
            for (int i = stack.Size - 1; i > 0; i--)
            {
                if (!stack.Get(i).Equals(default(T)))
                {
                    Console.Write("{0}  ", stack.Get(i));
                }
            }
          
            Console.Write("\n\n");
        }

        public void Push(T value)
        {
            if (IsFull())
            {
                Console.WriteLine("Can't_push:Stack_is_full");
            }
            else
            {               
                stack.Add(value);
                Counter++;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                 throw new Exception("Can't_dequeue:Queue_is_empty");
            }
            else
            {               
                T value = stack.GetLast();
                stack.RemoveLast();
                Counter--;
                Console.Write("Pop: ");
                return value;
            }

        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Can't_dequeue:Queue_is_empty");
            }
            else
            {
                T value = stack.GetLast();
                Console.Write("Peek: ");
                return value;
            }
        }
    }
}

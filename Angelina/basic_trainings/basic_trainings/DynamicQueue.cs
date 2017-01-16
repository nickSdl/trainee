using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class DynamicQueue<T> : IBuffer<T> where T : IComparable
    {
        private int Size;
        private int Counter;

        private DynamicArray<T> queue;
        
        public DynamicQueue(int Size)
        {
            queue = new DynamicArray<T>();
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
            Console.WriteLine("\nQueue:");
            for (int i = 0; i < queue.Size; i++)
            {
                if (!queue.Get(i).Equals(default(T)))
                {
                    Console.Write("{0}  ", queue.Get(i));
                }
            }

            Console.Write("\n\n");
        }

        public void Enqueue(T value)
        {
            if (IsFull())
            {
                Console.WriteLine("Can't_push:Queue_is_full");
            }
            else
            {                
                queue.Add(value);
                Counter++;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Can't_dequeue:Queue_is_empty");
            }
            else
            {              
                T value = queue.GetLast();
                queue.Remove(Counter-1);
                Counter--;
                Console.Write("Pop: ");
                return value;
            }
        }
    }
}

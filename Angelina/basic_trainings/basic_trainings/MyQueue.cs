using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class MyQueue<T> : IBuffer<T> where T: IComparable
    {
        private int Size;

        private T[] queue;

        private int _Head = 0;  //index of first insert value

        private int _Tail = 0; 

        public bool IsEmpty()
        {
            foreach (T value in queue)
            {
                if (!value.Equals(default(T)))
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsFull()
        {
            foreach (T value in queue)
            {
                if (value.Equals(default(T)))
                {
                    return false;
                }
            }
            return true;
        }
        
        public MyQueue(int Size)
        {
            this.Size = Size;
            queue = new T[Size];
        }

        public void Enqueue(T value)
        {
            if ((_Head == Size - 1) && (queue[_Head].Equals(default(T))))
            {
                queue[_Head] = value;
                _Head = 0;
            }
            else if (!queue[_Head].Equals(default(T)))
            {
                Console.WriteLine("Can't enqueue, queue is full");
            }
            else
            {
                queue[_Head] = value;
                _Head++;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())//!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            {
                Console.WriteLine("Can't_dequeue:Queue_is_empty");
                return default(T);
            }
            else
            {
                T value = queue[_Tail];
                queue[_Tail] = default(T);
                if (_Tail == Size - 1)
                {
                    _Tail = 0;
                }
                else
                {
                    _Tail++;
                }

                return value;
            }
        }

        public void Print()
        {
            if (!IsEmpty())
            {
                Console.WriteLine("\nQueue:");
            
                for (int i = _Tail; i != _Head; i++)
                {
                    Console.Write("{0}  ", queue[i]);

                    if (i == Size - 1)
                    {
                        i = -1;
                    }
                }
                Console.Write("\n\n");
            }
            else
            {
                Console.WriteLine("Can't dequeue: Queue is empty");

            }
        }
    }
}

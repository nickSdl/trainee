using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class MyQueue<T> : MyBuffer<T>, IBuffer<T> where T: IComparable
    {        
        private int _Head = 0;  //index of first insert value
        private int _Tail = 0; 

        public bool IsEmpty()
        {
            foreach (T value in buffer)
            {
                if (!value.Equals(default(T)))
                {
                    return false;
                }
            }
            
            onBufferEmpty(new BufferEventArgs());            
            return true;
        }

        public bool IsFull()
        {
            foreach (T value in buffer)
            {
                if (value.Equals(default(T)))
                {
                    return false;
                }
            }

            onBufferFull( new BufferEventArgs());            
            return true;
        }
        
        public MyQueue(int Size)
        {
            this.Size = Size;
            buffer = new T[Size];
        }

        public void Enqueue(T value)
        {
            try
            {
                // if ((_Head == Size - 1) && (queue[_Head].Equals(default(T))))
                if ((_Head == Size - 1) && !IsFull())
                {
                    buffer[_Head] = value;
                    _Head = 0;
                    onBufferAdded(new BufferEventArgs(), value);
                }
                //  else if (!queue[_Head].Equals(default(T)))
                else if (IsFull())
                {
                    throw new MyBufferException("MyBufferException: ''Can't enqueue: Queue is full''");
                }
                else
                {
                    buffer[_Head] = value;
                    _Head++;
                    onBufferAdded(new BufferEventArgs(), value);
                }
            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new MyBufferException("MyBufferException: ''Can't dequeue: Queue is empty''");
            }
            else
            {
                T value = buffer[_Tail];
                buffer[_Tail] = default(T);
                if (_Tail == Size - 1)
                {
                    _Tail = 0;
                }
                else
                {
                    _Tail++;
                }
                onBufferRemoved(new BufferEventArgs(), value);
                return value;
            }
        }

        public void Print()
        {
            try
            {
                if (!IsEmpty())
                {
                    Console.WriteLine("\nQueue:");

                    for (int i = _Tail; i != _Head; i++)
                    {
                        Console.Write("{0}  ", buffer[i]);

                        if (i == Size - 1)
                        {
                            i = -1;
                        }
                    }
                    Console.Write("\n\n");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

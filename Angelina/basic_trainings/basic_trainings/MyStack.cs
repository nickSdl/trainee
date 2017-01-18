using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{   
    class MyStack<T> : MyBuffer<T>, IBuffer<T> where T : IComparable
    {        
        public MyStack(int Size)
        {
            buffer = new T[Size];
            this.Size = Size;
        }        

        public bool IsEmpty()
        {
            if (buffer[0].Equals(default(T)))
            {
                onBufferEmpty(new BufferEventArgs());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFull()
        {
            if (!buffer[buffer.Length - 1].Equals(default(T)))
            {                
                onBufferFull(new BufferEventArgs());                
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            try
            {               
                if (!IsEmpty())
                {
                    Console.WriteLine("\nStack:");
                    foreach (T value in buffer)
                    {
                        if (!value.Equals(default(T)))
                        {
                            Console.Write("{0}  ", value);
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

        public void Push(T value)
        {
            try
            {
                if (IsFull())
                {
                    throw new MyBufferException("MyBufferException: ''Can't push: Stack is full''");
                }
                else
                {
                    for (int i = buffer.Length - 2; i >= 0; i--)
                    {
                        if (!buffer[i].Equals(default(T)))
                        {
                            buffer[i + 1] = buffer[i];
                        }
                    }
                    buffer[0] = value;

                    onBufferAdded(new BufferEventArgs(), value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public T Pop()
        {            
                if (IsEmpty())
                {
                    throw new MyBufferException("MyBufferException: ''Can't pop: Stack is empty''");                  
                }                                   
               else //if (!IsEmpty())
                {
                    T value = buffer[0];
                    for (int i = 0; i < buffer.Length - 1; i++)
                    {
                        if (!buffer[i + 1].Equals(default(T)))
                        {
                        buffer[i] = buffer[i + 1];
                        }
                        else// (stack[i+1] == null)
                        {
                        buffer[i] = default(T);
                        }
                    }

                    if (!buffer[buffer.Length - 1].Equals(default(T)))
                    {
                        buffer[buffer.Length - 1] = default(T);
                    }
                   
                    onBufferRemoved(new BufferEventArgs(),value);                   
                   
                    return value;
                }            
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new MyBufferException("MyBufferException: ''Can't peek: Stack is empty''");
            }
            else     
            {
                return buffer[0];
            }
        }
            
            
        
    }
}

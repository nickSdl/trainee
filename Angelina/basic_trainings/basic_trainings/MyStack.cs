using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{   
    class MyStack<T> : IBuffer<T> where T : IComparable
    {
        private T[] stack;
        
        private int Size;

        public MyStack(int Size)
        {
            stack = new T[Size];
            this.Size = Size;
        }        

        public bool IsEmpty()
        {
            if (stack[0].Equals(default(T)))
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
            if (!stack[stack.Length - 1].Equals(default(T)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            Console.WriteLine("\nStack:");
            foreach (T value in stack)
            {
                if (!value.Equals(default(T)))
                {
                    Console.Write("{0}  ", value);
                }
            }
            Console.Write("\n\n");
        }

        public void Push(T value)
        {           
            if(IsFull())
            {
                Console.WriteLine("Can't_push:Stack_is_full");
            }            
            else
            {
                for (int i = stack.Length - 2; i >= 0; i--)
                {
                    if(!stack[i].Equals(default(T)))
                    {
                        stack[i + 1] = stack[i];
                    }
                }
                stack[0] = value;
            }
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                 Console.WriteLine("Can't_dequeue:Queue_is_empty");
                 return default(T);
               
                   // throw new Exception("Can't_dequeue:Queue_is_empty");
                          
            }
            else
            {
                T value = stack[0];
                for (int i=0; i<stack.Length-1; i++)
                {
                    if (!stack[i + 1].Equals(default(T)))
                    {
                        stack[i] = stack[i + 1];
                    }
                    else// (stack[i+1] == null)
                    {
                        stack[i] = default(T);
                    }                     
                    
                }

                if (!stack[stack.Length-1].Equals(default(T)))
                {
                    stack[stack.Length - 1] = default(T);
                }

                Console.Write("Pop: ");
                return value;
            }

        }

        public T Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Can't_dequeue:Queue_is_empty");
                return default(T);
            }
            else
            {
                Console.Write("Peek: ");
                return stack[0];
            }
        }
    }
}

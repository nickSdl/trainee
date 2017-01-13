using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class MyStack:Buffer
    {
        private int?[] stack;

        public override bool IsEmpty
        {
            get { CheckStack(); return _IsEmpty; }
        }

        public override bool IsFull
        {
            get { CheckStack(); return _IsFull; }
        }

        private int Size;

        public MyStack(int Size)
        {
            stack = new int?[Size];
            this.Size = Size;
        }

        private void CheckStack()
        {
            _IsEmpty = (stack[0] == null) ? true : false;
            _IsFull = (stack[stack.Length-1] != null) ? true : false;

        }

        public void Push(int value)
        {           
               // stack.Insert(stack.Count, value);
            if(stack[stack.Length-1]!=null)
            {
                Console.WriteLine("Can't_push:Stack_is_full");
            }            
            else
            {
                for (int i = stack.Length - 2; i >= 0; i--)
                {
                    if(stack[i]!=null)
                    {
                        stack[i + 1] = stack[i];
                    }
                }
                stack[0] = value;
            }
        }

        public int? Pop()
        {
            if (stack[0] == null)
            {
                Console.Write("Can't_pop:Stack_is_empty");
                return null;
            }
            else
            {
                int? value = stack[0];
                for (int i=0; i<stack.Length-1; i++)
                {
                    if (stack[i + 1] != null)
                    {
                        stack[i] = stack[i + 1];
                    }
                    else// (stack[i+1] == null)
                    {
                        stack[i] = null;
                    }                     
                    
                }
                if (stack[stack.Length-1] != null)
                {
                    stack[stack.Length - 1] = null;
                }

                Console.Write("Pop: ");
                return value;
            }

        }

        public int? Peek()
        {
            if (stack[0] == null)
            {
                Console.Write("Stack_is_empty");
                return null;
            }
            else
            {
                Console.Write("Peek: ");
                return stack[0];
            }
        }
    }
}

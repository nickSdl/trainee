using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class MyQueue
    {
        //private static int maxCount = 10;

        private int Size;

        //private int?[] queue = new int?[maxCount];

        private int?[] queue;

        private int _Head = 0;  //index of first insert value

        private int _Tail = -1; //become 0 after insertion of first element при добавлении 1го элемента станет 0, что и будет индексом первого элемента
                                //_Tail should be less than _Head on 1

        private bool _IsEmpty;
        public bool IsEmpty
        {
            get { CheckQueue(); return _IsEmpty; }
        }

        private bool _IsFull;
        public bool IsFull
        {
            get { CheckQueue(); return _IsFull; }
        }



        public MyQueue(int Size)
        {
            this.Size = Size;
            queue = new int?[Size];
        }

        private void CheckQueue()
        {
            _IsEmpty = true;
            _IsFull = true;

            foreach (int? value in queue)
            {
                if (value != null)
                {
                    _IsEmpty = false;
                }
                else
                {
                    _IsFull = false;
                }
            }
        }

        public void Enqueue(int value)
        {    
                  
            if ((_Head == Size - 1) && (queue[_Head] == null))
            {
                queue[_Head] = value;
                _Head = 0;
            }
            else if (queue[_Head] != null)
            {
                Console.WriteLine("Can't enqueue, queue is full");
            }
            else
            {
                queue[_Head] = value;
                _Head++;
            }

            if (_Tail == -1)
            {
                _Tail++;
            }

               

            
        }

        public int? Dequeue()
        {
            if (_Tail == -1 || queue[_Tail] == null)
            {
                Console.Write("Can't_dequeue:Queue_is_empty");
                return null;
            }
            else
            {
                int? value = queue[_Tail];
                queue[_Tail] = null;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class DynamicArray<T>
    {
        private T[] DynArray;

        public int Capacity { get; private set; }

        public int Size { get; private set; }

        public int MaxSize { get; private set; }

        public DynamicArray()
        {
            this.Capacity = 10;
            DynArray = new T[Capacity];
            this.Size = 0;
            this.MaxSize = 5000;
        }

        /*
        public DynamicArray(int Capacity)
        {
            this.Capacity = Capacity;
            DynArray = new T[Capacity];
            this.Size = 0;
        }
        */

     /*   public DynamicArray(int MaxSize)
        {
            this.MaxSize = MaxSize;
            this.Capacity = 10;//Capacity can increase until it will become equal to MaxSize !!!!!!!!!!!!!!!!!!!!!!!!!!!
            DynArray = new T[Capacity];
            this.Size = 0;
        }*/

        public void Add(T item)
        {
            if (Size == Capacity || Size == Capacity - 1)
            {                
                Capacity *= 2;               
                Array.Resize(ref DynArray, Capacity);
            }
            
            DynArray[Size] = item;
            Size++;
            
           
        }

        public void Insert(T item, int index)
        {

            if (index >= Size || index < 0)//wrong index
            {
                Console.WriteLine("Can't insert: Index should be in the range from 0 to {0}", Size-1);
            }
            else
            {
                if (Size == Capacity || Size == Capacity - 1)
                {
                  /*  if(Capacity*2<=MaxSize)
                    {*/
                        Capacity *= 2;
                  /*  }
                    else
                    {
                        Capacity = MaxSize;
                    }*/
                    Array.Resize(ref DynArray, Capacity);


                }
              
                    for (int i = index; i < Size; i++)
                    {
                        DynArray[i + 1] = DynArray[i];
                    }
                    DynArray[index] = item;
                    Size++;                
            }              
                
        }

        public T Get(int index)
        {
            if (index >= Size)
            {
                Console.WriteLine("Can't remove: Index should be in the range from 0 to {0}", Size - 1);
                return DynArray[index];

            }
            else
            {
                return DynArray[index];
            }
        }        

        public void Remove(int index)
        {
            if (index >= Size)
            {
                Console.WriteLine("Can't remove: Index should be in the range from 0 to {0}", Size-1);
            }
            else
            {
                for (int i = index; i < Size-1; i++)
                {
                    DynArray[i] = DynArray[i + 1];
                }
                DynArray[Size - 1] = default(T);
                Size--;
            }
        }

       



    }
}

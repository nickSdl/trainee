using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class DynamicArray<T>: IPrintable<T>
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

        public DynamicArray(int MaxSize)
        {
            this.MaxSize = MaxSize;
            this.Capacity = 10; //Capacity can increase until it will become equal to MaxSize
            DynArray = new T[Capacity];
            this.Size = 0;
        }

        public void Add(T item)
        {
            if (Size == Capacity )
            {
                DoubleCapacity();
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
                if (Size == Capacity )
                {
                    DoubleCapacity();
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
            if (Size==0)
            {
                return default(T);
            }
            if (index >= Size || index<0)
            {
                throw new IndexOutOfRangeException("Wrong index");              
            }
            else
            {
                return DynArray[index];
            }
        }

        public T GetLast()
        {
            return Get(Size - 1);
        }

        public void Remove(int index )
        {
            if (index >= Size || index < 0)
            {
                throw new IndexOutOfRangeException("Wrong index");
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

        public void RemoveLast()
        {
            Remove(Size - 1);
        }

        private void ResizeArray(int newLength)
        {
            T[] tempArray = new T[newLength];
            for (int i = 0; i < Size; i++)
                tempArray[i] = DynArray[i];
            DynArray = tempArray;
            if (Capacity < newLength)
                Capacity = newLength;
        }

        private void DoubleCapacity()
        {
            if (Capacity == MaxSize)
            {
                throw new Exception("Capacity can't be greater than maximum size");
            }
            else if (Capacity * 2 > MaxSize)
            {
                Capacity *= 2;
            }
            else
            {
                Capacity *= 2;
            }
            ResizeArray(Capacity);
        }

        public void Print()
        {
            Console.WriteLine("Array:");
            for (int i = 0; i < Size; i++)
                Console.WriteLine(Get(i));
            Console.WriteLine("\n");
        }

        public void Swap(int index1, int index2)
        {
            T temp = DynArray[index1];
            DynArray[index1] = DynArray[index2];
            DynArray[index2] = temp;
        }

    }
}

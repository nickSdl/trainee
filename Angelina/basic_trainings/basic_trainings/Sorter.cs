using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
     abstract class Sorter<T>: ISorter<T> where T:IComparable
    {
       protected T[] array;

       public Sorter(T[] array)
        {
            this.array = new T[array.Length];
            Array.Copy(array, this.array, array.Length);

            /*
            //initial array will change
            this.array = new int[array.Length];
            this.array = array;
            */
        }

       public void Print()
        {
            Console.WriteLine("Array:");
            foreach (T value in array)
            {
                Console.Write("{0}  ", value);
            }
            Console.Write("\n");
        }

        public abstract void Sort();        

        public void Swap(ref T[] arr, int index1, int index2)
        {
            T temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

        

    }

}

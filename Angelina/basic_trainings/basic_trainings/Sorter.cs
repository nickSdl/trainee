using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    abstract class Sorter
    {
       protected int[] array;

       public Sorter(int[] array)
        {
            this.array = new int[array.Length];
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
            foreach (int value in array)
            {
                Console.Write("{0}  ", value);
            }
            Console.Write("\n");
        }

        public virtual void Sort()
        {
            Console.WriteLine("Sorting");
        }

        public void Swap(ref int[] arr, int index1, int index2)
        {
            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }
    }
}

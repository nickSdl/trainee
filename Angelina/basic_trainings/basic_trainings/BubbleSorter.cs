using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class BubbleSorter<T> : Sorter<T> where T : IComparable
    {
        public BubbleSorter(T[] array) : base(array)
        { }

        public override void Sort()
        {
            if (array.Length != 0)
            {
                for (int i = 0; i < array.Length; i++)
                    for (int j = array.Length - 1; j > i; j--)
                        if (array[j].CompareTo(array[j - 1]) < 0)//class can has it's own realization of method CompareTo()                       
                        {
                            Swap(ref array, j, j - 1);
                        }
            }
            else
            {
                Console.WriteLine("Can't sort, this array is empty");
            }
        }


    }
}

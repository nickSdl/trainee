using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class InsertionSorter : Sorter
    {
        public InsertionSorter(int[] array) : base(array)
        { }

        public override void Sort()
        {
            if (array.Length != 0)
            {
                for (int i = 0; i < array.Length; i++)
                    for (int j = array.Length - 1; j > i; j--)
                        if (array[j] < array[j - 1])
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

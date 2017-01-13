using System;

namespace Lesson5.Sorter
{
	public class InsertionSorter<T> : SorterBase<T> where T: IComparable
	{
		public InsertionSorter(T[] array)
		{
			this.array = array;
		}

		public override void Sort()
		{
			for (int i = 1; i < array.Length; i++)
			{
				int j = i;
				while ((j > 0) && (array[j].CompareTo(array[j - 1])) == 1)
				{
					int k = j - 1;
					Swap(k, j);
					j--;
				}
			}
		}
	}
}

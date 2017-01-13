using System;

namespace Lesson5.Sorter
{
	public class BubbleSorter<T> : SorterBase<T> where T : IComparable
	{
		public BubbleSorter(T[] array)
		{
			this.array = array;
		}
		
		public override void Sort()
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[i].CompareTo(array[j]) == 1)
					{
						Swap(i, j);
					}
				}
			}
		}
	}
}

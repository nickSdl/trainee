using System;

namespace Lesson5.Sorter
{
	public class BubbleSorter : SorterBase
	{
		public BubbleSorter(int[] array)
		{
			this.array = array;
		}

		private void Swap(int firstIndex, int secondIndex)
		{
			int temp;
			temp = array[firstIndex];
			array[firstIndex] = array[secondIndex];
			array[secondIndex] = temp;
		}

		public override void Sort()
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = i + 1; j < array.Length; j++)
				{
					if (array[i] > array[j])
					{
						Swap(i, j);
					}
				}
			}
		}
	}
}

using System;

namespace Lesson5
{
	public class BubbleSorter
	{
		private int[] array;

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

		public void Sort()
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

		public void Print()
		{
			foreach (int item in array)
			{
				Console.WriteLine(item);
			}
		}
	}
}

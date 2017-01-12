using System;

namespace Lesson5
{
	public class InsertionSorter
	{
		private int[] array;

		public InsertionSorter(int[] array)
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
			for (int i = 1; i < array.Length; i++)
			{
				int j = i;
				while ((j > 0) && (array[j] < array[j - 1]))
				{
					int k = j - 1;
					Swap(k, j);
					j--;
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

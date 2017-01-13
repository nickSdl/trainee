using System;

namespace Lesson5.Sorter
{
	public abstract class SorterBase
	{
		protected int[] array;

		public abstract void Sort();
		
		public virtual void Print()
		{
			foreach (int item in array)
			{
				Console.WriteLine(item);
			}
		}
	}
}

using System;
using Lesson5.Interfaces;

namespace Lesson5.Sorter
{
	public abstract class SorterBase<T> : ISorter<T>
	{
		protected T[] array;

		protected  virtual void Swap(int firstIndex, int secondIndex)
		{
			T temp;
			temp = array[firstIndex];
			array[firstIndex] = array[secondIndex];
			array[secondIndex] = temp;
		}

		public abstract void Sort();
		
		public virtual void Print()
		{
			foreach (T item in array)
			{
				Console.WriteLine(item);
			}
		}
	}
}

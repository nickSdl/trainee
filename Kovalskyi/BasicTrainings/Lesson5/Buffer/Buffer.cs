using System;
using Lesson5.Interfaces;

namespace Lesson5.Buffer
{
	public abstract class Buffer<T> : IBuffer<T>
	{
		protected T[] array;

		public abstract bool IsFull();

		public abstract bool IsEmpty();

		public abstract T Peek();

		public virtual void Print()
		{
			foreach (T item in array)
			{
				Console.WriteLine(item);
			}
		}
	}
}

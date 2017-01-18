using System;
using Lesson5.Interfaces;

namespace Lesson5.Buffer
{
	public delegate void BufferStateHandler(object sender, BufferEventArgs e);

	public abstract class Buffer<T> : IBuffer<T>
	{
		public event BufferStateHandler Added;

		public event BufferStateHandler Removed;

		protected T[] array;

		protected virtual void OnAddChanged(BufferEventArgs e)
		{
			BufferStateHandler AddHandler = Added;
			if (AddHandler != null)
			{
				AddHandler(this, e);
			}
		}

		protected virtual void OnRemoveChanged(BufferEventArgs e)
		{
			BufferStateHandler RemovedHandler = Added;
			if (RemovedHandler != null)
			{
				RemovedHandler(this, e);
			}
		}

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

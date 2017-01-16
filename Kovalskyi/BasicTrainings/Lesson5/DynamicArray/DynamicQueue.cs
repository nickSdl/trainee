using System;

namespace Lesson5.DynamicArray
{
	public class DynamicQueue<T>
	{
		private DynamicArray<T> list;
		private int head = 0;
		private int tail = 0;
		private int maxLength;

		public DynamicQueue(int length)
		{
			this.maxLength = length + 1;
			this.list = new DynamicArray<T>(length);
		}

		public void Enqueue(T item)
		{
			if (IsFull())
			{
				throw new Exception("Queue is full.");
			}
			list.Insert(tail, item);
			tail = (tail + 1) % maxLength;
		}

		public T Dequeue()
		{
			if (IsEmpty())
			{
				throw new Exception("Queue is empty.");
			}
			T firstInQueue = list.Remove(head);
			head = (head + 1) % maxLength;
			return firstInQueue;
		}

		public T Peek()
		{
			if (IsEmpty())
			{
				throw new InvalidOperationException("Queue is empty.");
			}
			T lastItem = list.Get(head);
			return lastItem;
		}

		public bool IsEmpty()
		{
			return (head == tail);
		}

		public bool IsFull()
		{
			return (head == (tail + 1) % maxLength);
		}
	}
}

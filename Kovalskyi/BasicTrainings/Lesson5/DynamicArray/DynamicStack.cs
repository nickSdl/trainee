using System;

namespace Lesson5.DynamicArray
{
	public class DynamicStack<T>
	{
		private int arrayLength;
		private DynamicArray<T> list;
		
		public DynamicStack(int length)
		{
			arrayLength = length;
			list = new DynamicArray<T>(length);
		}

		public int Count()
		{
			if (IsEmpty())
			{
				return 0;
			}
			else
			{
				return list.Size;
			}
		}

		public T Pop()
		{
			if (IsEmpty())
			{
				throw new InvalidOperationException("Stack is empty.");
			}
			T lastItem = list.Remove(list.Size - 1);
			return lastItem;
		}

		public void Push(T item)
		{
			list.Add(item);
		}

		public T Peek()
		{
			if (IsEmpty())
			{
				throw new InvalidOperationException("Stack is empty.");
			}
			T lastItem = list.Get(list.Size - 1);
			return lastItem;
		}

		public bool IsEmpty()
		{
			return (list == null);
		}

		public bool IsFull()
		{
			if (IsEmpty())
			{
				return false;
			}
			return (arrayLength == list.Capacity);
		}
	}
}

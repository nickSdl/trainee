using System;
using Lesson5.Interfaces;

namespace Lesson5.Buffer
{
	public class MyStack<T> : Buffer<T>, IMyStack<T>
	{
		private int arrayLength;

		private void ArrayResize(int step)
		{
			T[] temp = new T[array.Length + step];
			for (int i = 0; i < array.Length; i++)
			{
				temp[i] = array[i];
			}
			array = temp;
		}

		public MyStack(int length)
		{
			arrayLength = length;
		}

		public int Count()
		{
			if (IsEmpty())
			{
				return 0;
			}
			else
			{
				return array.Length;
			}
		}

		public T Pop()
		{
			if (IsEmpty())
			{
				throw new InvalidOperationException("Stack is empty.");
			}
			else
			{
				T lastItem = array[array.Length - 1];
				ArrayResize(-1);
				return lastItem;
			}
		}

		public void Push(T item)
		{
			if (IsFull())
			{
				throw new InvalidOperationException("Stack is full.");
			}
			else if (IsEmpty())
			{
				array = new T[] { item };
			}
			else
			{
				ArrayResize(1);
				array[array.Length - 1] = item;
			}
		}

		public override T Peek()
		{
			if (IsEmpty())
			{
				throw new InvalidOperationException("Stack is empty.");
			}
			else
			{
				T lastItem = array[array.Length - 1];
				return lastItem;
			}
		}

		public override bool IsEmpty()
		{
			return (array == null);
		}

		public override bool IsFull()
		{
			if (IsEmpty())
			{
				return false;
			}
			return (arrayLength == array.Length);
		}
	}
}

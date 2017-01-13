using System;

namespace Lesson5.Buffer
{
	public class MyStack : Buffer
	{
		private int[] array;
		private int arrayLength;

		private void ArrayResize(int step)
		{
			int[] temp = new int[array.Length + step];
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

		public int Pop()
		{
			if (IsEmpty())
			{
				throw new InvalidOperationException("Stack is empty.");
			}
			else
			{
				int lastItem = array[array.Length - 1];
				ArrayResize(-1);
				return lastItem;
			}
		}

		public void Push(int item)
		{
			if (IsFull())
			{
				throw new InvalidOperationException("Stack is full.");
			}
			else if (IsEmpty())
			{
				array = new int[] { item };
			}
			else
			{
				ArrayResize(1);
				array[array.Length - 1] = item;
			}
		}

		public int Peek()
		{
			if (IsEmpty())
			{
				throw new InvalidOperationException("Stack is empty.");
			}
			else
			{
				int lastItem = array[array.Length - 1];
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

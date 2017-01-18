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
			for (int i = 0; i < array.Length - 1; i++)
			{
				temp[i] = array[i];
			}
			array = temp;
		}

		public MyStack(int length)
		{
			arrayLength = length;
			ShowBufferState showState = new ShowBufferState();
			Added += showState.ShowEvent;
			Removed += showState.ShowEvent;
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
				throw new BufferOutOfRangeException("Stack is empty.");
			}
			T lastItem = array[array.Length - 1];
			ArrayResize(-1);
			if (array.Length == 0)
			{
				OnAddChanged(new BufferEventArgs("Stack is empty."));
			}
			return lastItem;
		}

		public void Push(T item)
		{
			if (IsFull())
			{
				throw new BufferOutOfRangeException("Stack is full.");
			}
			else if (IsEmpty())
			{
				array = new T[] { item };
				if (IsFull())
				{
					OnRemoveChanged(new BufferEventArgs("Stack is full."));
				}
			}
			else
			{
				ArrayResize(1);
				array[array.Length - 1] = item;
				if (IsFull())
				{
					OnRemoveChanged(new BufferEventArgs("Stack is full."));
				}
			}
		}

		public override T Peek()
		{
			if (IsEmpty())
			{
				throw new BufferOutOfRangeException("Stack is empty.");
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

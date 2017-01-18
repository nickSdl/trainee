using System;
using Lesson5.Interfaces;

namespace Lesson5.Buffer
{
	public class MyQueue<T> : Buffer<T>, IMyQueue<T>
	{
		private int head = 0;
		private int tail = 0;
		private int maxLength;

		public MyQueue(int length)
		{
			this.maxLength = length + 1;
			this.array = new T[length];
			ShowBufferState showState = new ShowBufferState();
			Added += showState.ShowEvent;
			Removed += showState.ShowEvent;
		}

		public void Enqueue(T item)
		{
			if (IsFull())
			{
				throw new BufferOutOfRangeException("Queue is full.");
			}
			array[tail] = item;
			tail = (tail + 1) % maxLength;
			if (IsFull())
			{
				OnAddChanged(new BufferEventArgs("Queue is full"));
			}
		}

		public T Dequeue()
		{
			if (IsEmpty())
			{
				throw new BufferOutOfRangeException("Queue is empty.");
			}
			T firstInQueue = array[head];
			array[head] = default(T);
			head = (head + 1) % maxLength;
			if (IsEmpty())
			{
				OnRemoveChanged(new BufferEventArgs("Queue in empty"));
			}
			return firstInQueue;
		}

		public override T Peek()
		{
			if (IsEmpty())
			{
				throw new BufferOutOfRangeException("Queue is empty.");
			}
			else
			{
				T lastItem = base.array[head];
				return lastItem;
			}
		}

		public override bool IsEmpty()
		{
			return (head == tail);
		}

		public override bool IsFull()
		{
			return (head == (tail + 1) % maxLength);
		}
	}
}

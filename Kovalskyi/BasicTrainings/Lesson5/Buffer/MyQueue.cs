using System;

namespace Lesson5.Buffer
{
	public class MyQueue : Buffer
	{
		private int head = 0;
		private int tail = 0;
		private int[] arr;
		private int maxLength;

		public MyQueue(int length)
		{
			this.maxLength = length + 1;
			this.arr = new int[length];
		}

		public void Enqueue(int item)
		{
			if (IsFull())
			{
				throw new Exception("Queue is full.");
			}
			arr[tail] = item;
			tail = (tail + 1) % maxLength;
		}

		public int Dequeue()
		{
			if (IsEmpty())
			{
				throw new Exception("Queue is empty.");
			}
			int firstInQueue = arr[head];
			arr[head] = 0;
			head = (head + 1) % maxLength;
			return firstInQueue;
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

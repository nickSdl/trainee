using System;

namespace Lesson5.DynamicArray
{
	public class DynamicArray<T>
	{
		const int SIZE_COEFFICIENT = 2;
		private T[] array;
		private int maxSize;
		public int Capacity { get; private set; }
		public int Size { get; private set; }

		private bool IsEmpty()
		{
			return (array == null);
		}

		private void ArrayResize(int size)
		{
			size *= SIZE_COEFFICIENT;
			T[] temp = new T[size];
			for (int i = 0; i < array.Length; i++)
			{
				temp[i] = array[i];
			}
			array = temp;
		}

		public DynamicArray(int capacity) : this(capacity, Int32.MaxValue / 2)
		{
			
		}

		public DynamicArray(int capacity, int maxSize) 
		{
			this.Capacity = capacity;
			array = new T[capacity];
			this.maxSize = maxSize;
		}
		
		public void Add(T item)
		{
			if (Size == maxSize)
			{
				throw new Exception("List is full.");
			}
			if (Size == Capacity)
			{
				ArrayResize(Capacity);
			}
			array[Size] = item;
			Size++;
		}

		public void Insert(int position, T item)
		{
			if (Size == maxSize)
			{
				throw new Exception("List is full.");
			}
			if (IsEmpty())
			{
				throw new NullReferenceException("List is Empty.");
			}
			if (position > Size)
			{
				throw new NullReferenceException("Position doesn't exist.");
			}
			else if (Size == Capacity)
			{
				ArrayResize(Capacity);
			}
			int temp = Size;
			while (temp != position)
			{
				array[temp] = array[temp - 1];
				temp--;
			}
			array[position] = item;
			Size++;
		}

		public T Get(int position)
		{
			if (IsEmpty())
			{
				throw new NullReferenceException("List is Empty.");
			}
			else if (position > array.Length)
			{
				throw new NullReferenceException("Position doesn't exist.");
			}
			return array[position];
		}

		public T Remove	(int position)
		{
			if (IsEmpty())
			{
				throw new NullReferenceException("List is Empty.");
			}
			if (position > Size)
			{
				throw new NullReferenceException("Position doesn't exist.");
			}
			T item;
			item = array[position];
			int temp = position;
			while (temp != Size)
			{
				array[position] = array[position +1];
				temp++;
			}
			Size-- ;
			return item;
		}
	}
}

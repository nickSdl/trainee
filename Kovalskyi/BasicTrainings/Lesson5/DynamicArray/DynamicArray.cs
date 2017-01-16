using System;

namespace Lesson5.DynamicArray
{
	public class DynamicArray<T>
	{
		private T[] array;
		public int Capacity { get; private set; }
		public int Size { get; private set; }

		private bool IsEmpty()
		{
			return (array == null);
		}

		private void ArrayResize(int step)
		{
			T[] temp = new T[array.Length + step];
			for (int i = 0; i < array.Length; i++)
			{
				temp[i] = array[i];
			}
			array = temp;
		}
		
		public DynamicArray(int capacity)
		{
			this.Capacity = capacity;
			array = new T[capacity];
		}
		
		public void Add(T item)
		{
			if (Size < Capacity)
			{
				array[Size] = item;
				Size++;
			}
			else if(Size == Capacity)
			{
				Capacity *= 2;
				ArrayResize(Capacity);
				array[Size] = item;
				Size++;
			}
			
		}
		public void Insert(int position, T item)
		{
			if (IsEmpty())
			{
				throw new NullReferenceException("List is Empty.");
			}
			else if (position > Size)
			{
				throw new NullReferenceException("Position doesn't exist.");
			}
			else
			{
				int temp = Size;
				while (temp != position)
				{
					array[temp] = array[temp - 1];
					temp--;
				}
				array[position] = item;
				Size++;
			}
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
			else
			{
				return array[position];
			}
		}

		public T Remove	(int position)
		{
			T item;
			if (IsEmpty())
			{
				throw new NullReferenceException("List is Empty.");
			}
			else if (position > Size)
			{
				throw new NullReferenceException("Position doesn't exist.");
			}
			else if (position == Size - 1)
			{
				item = array[position];
				Size--;
				return item;
			}
			else
			{
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
}

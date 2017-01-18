using System;

namespace Lesson5.LinkedList
{
	/// <summary>
	/// The LinkedList is realized by Olexander Kovalskyi.
	/// </summary>
	/// <typeparam name="T"> Type of data in a list.</typeparam>
	public class MyLinkedList<T>
	{
		/// <summary>
		/// The Store for the head pointer.
		/// </summary>
		private Node<T> head;
		private int size;

		/// <summary>
		/// The Constructor initializes size and head of a list.
		/// </summary>
		public MyLinkedList()
		{
			this.head = null;
			this.size = 0;
		}

		/// <summary>
		/// Check list for null.
		/// </summary>
		public bool IsEmpty()
		{
			return size == 0;
		}

		/// <summary>
		/// Get count of elements in a list.
		/// </summary>
		/// <returns>
		/// Return a count of elements in a list.
		/// </returns>
		public int Count()
		{
			return size;
		}

		/// <summary>
		/// Insert element by index.
		/// </summary>
		/// <param name="index">Index in a list.</param>
		/// <param name="item">Data what you want to put into a list.</param>
		public void Insert(int index, T item)
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("Index: " + index);
			}
			if (index > size)
			{
				index = size;
			}
			Node<T> current = head;
			if (this.IsEmpty() || index == 0)
			{
				head = new Node<T>(item, head);
			}
			else
			{
				for (int i = 0; i < index - 1; i++)
				{
					current = current.Next;
				}
				current.Next = new Node<T>(item, current.Next);
			}
			size++;
		}

		/// <summary>
		/// Add element at the end of a list.
		/// </summary>
		/// <param name="item">Data what you want to put into a list.</param>
		public void Add(T item)
		{
			Insert(size, item);
		}

		/// <summary>
		/// Remove data from a list by index.
		/// </summary>
		/// <param name="index">Index of data for remove.</param>
		/// <returns>Return data by index.</returns>
		public T Remove(int index)
		{
			if (index < 1)
			{
				throw new ArgumentOutOfRangeException("index: " + index);
			}
			if (IsEmpty())
			{
				throw new ArgumentNullException("List is empty.");
			}
			if (index > size)
			{
				index = size - 1;
			}
			Node<T> current = head;
			T result;
			if (index == 0)
			{
				result = current.Data;
				head = current.Next;
			}
			else
			{
				for (int i = 0; i < index - 1; i++)
				{
					current = current.Next;
				}
				result = current.Next.Data;
				current.Next = current.Next.Next;
			}
			return result;
		}

		/// <summary>
		/// Get data from a list by index.
		/// </summary>
		/// <param name="index">Index of data to get.</param>
		/// <returns>Return data by index.</returns>
		public T Get(int index)
		{
			if (index < 1)
			{
				throw new ArgumentOutOfRangeException("index: " + index);
			}
			if (IsEmpty())
			{
				throw new ArgumentNullException("List is empty.");
			}
			if (index >= size)
			{
				index = size - 1;
			}
			Node<T> current = head;

			for (int i = 0; i < index; i++)
			{
				current = current.Next;
			}
			size--;
			return current.Data;
		}
		
		/// <summary>
		/// Clear list.
		/// </summary>
		public void Clear()
		{
			head = null;
			size = 0;
		}	
	}
}

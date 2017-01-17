using System;

namespace Lesson5.DoublLinkedList
{
	public class DoublLinkedList<T>
	{
		private Node<T> head;
		private Node<T> last;
		private int size;

		public DoublLinkedList()
		{
			this.head = this.last = null;
			this.size = 0;
		}

		public bool IsEmpty()
		{
			return size == 0;
		}

		public int Count()
		{
			return size;
		}

		public void Insert(int index, T item)
		{
			if (index < 1 || index > size)
			{
				throw new InvalidOperationException("Invalid index");
			}
			if (index == 1)
			{
				AddFront(item);
			}
			else if (index == size)
			{
				AddBack(item);
			}
			int count = 0;
			Node<T> temp = head;
			while (temp != null && count != index)
			{
				temp = temp.Next;
				count++;
			}
			Node<T> current = new Node<T>(item);
			temp.Prev.Next = current;
			current.Prev = temp.Prev;
			temp.Prev = current;
			current.Next = temp;
		}

		public T Remove(int index)
		{
			if (index < 1 || index > size)
			{
				throw new InvalidOperationException("Invalid index");
			}
			if (index == 1)
			{
				PopFront();
			}
			else if (index == size)
			{
				PopBack();
			}
			int count = 0;
			Node<T> temp = head;
			while (temp != null && count != index)
			{
				temp = temp.Next;
				count++;
			}
			T result = temp.Data;
			temp.Prev.Next = temp.Next;
			temp.Next.Prev = temp.Prev;
			return result;
		}

		public void AddFront(T item)
		{
			Node<T> current = new Node<T>(item);
			if (head == null)
			{
				head = last = current;
			}
			else
			{
				current.Next = head;
				head = current;
				current.Next.Prev = head;
			}
			size++;
		}

		public void AddBack(T item)
		{
			Node<T> current = new Node<T>(item);
			if (head == null)
			{
				head = last = current;
			}
			else
			{
				last.Next = current;
				current.Prev = last;
				last = current;
			}
			size++;
		}

		public T PopFront()
		{
			if (head == null)
			{
				throw new InvalidOperationException("List is Empty");
			}
			Node<T> current = head;
			T result = head.Data;
			if (head.Next != null)
			{
				head.Next.Prev = null;
			}
			head = head.Next;
			size--;
			return result;
		}

		public T PopBack()
		{
			if (last == null)
			{
				throw new InvalidOperationException("List is Empty");
			}
			Node<T> current = last;
			T result = last.Data;
			if (last.Prev != null)
			{
				last.Prev.Next = null;
			}
			last = last.Prev;
			size--;
			return result;
		}
	}
}

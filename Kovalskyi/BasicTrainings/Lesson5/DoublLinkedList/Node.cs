using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.DoublLinkedList
{
	public class Node<T>
	{
		private T data;
		private Node<T> next;
		private Node<T> prev;

		public Node(T data)
		{
			this.data = data;
		}

		public T Data
		{
			get
			{
				return this.data;
			}
			set
			{
				this.data = value;
			}
		}

		public Node<T> Next
		{
			get
			{
				return this.next;
			}
			set
			{
				this.next = value;
			}
		}

		public Node<T> Prev
		{
			get
			{
				return this.prev;
			}
			set
			{
				this.prev = value;
			}
		}
	}
}

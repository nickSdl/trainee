using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.LinkedList
{
	public class Node<T>
	{
		private T data;
		private Node<T> next;

		public Node(T data, Node<T> next)
		{
			this.data = data;
			this.next = next;
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
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Buffer
{
	public class BufferOutOfRangeException : Exception
	{
		public BufferOutOfRangeException()
		{
		}

		public BufferOutOfRangeException(string message) : base (message)
		{
		}

		public BufferOutOfRangeException(string message, Exception inner) : base(message, inner)
		{
		}

		public override string Message
		{
			get
			{
				return "Buffer is full or empty.";
			}
		}
	}
}

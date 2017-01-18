using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Buffer
{
	public class BufferEventArgs : EventArgs
	{
		public string message;

		public BufferEventArgs(string message)
		{
			this.message = message;
		}
	}
}

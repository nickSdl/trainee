using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5.Buffer
{
	public class ShowBufferState
	{
		public void ShowEvent(object sender, BufferEventArgs e)
		{
			Console.WriteLine(e.message);
		}
	}
}

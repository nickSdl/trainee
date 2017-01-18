using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class BufferEventArgs : EventArgs
    {
        public string message;

        public BufferEventArgs()
        {        }

        public BufferEventArgs(string message)
        {
            this.message = message;
        }
    }
}

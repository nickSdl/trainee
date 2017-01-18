using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    abstract class MyBuffer<T>
    {
        protected int Size;
        protected T[] buffer;

        public delegate void BufferHandler(object sender, BufferEventArgs e);
        public event BufferHandler BufferAdded;
        public event BufferHandler BufferRemoved;
        public event BufferHandler BufferEmpty;
        public event BufferHandler BufferFull;

        protected virtual void onBufferAdded(BufferEventArgs e, T value)
        {
            if (BufferAdded != null)
            {
                BufferAdded(this, new BufferEventArgs("_Value was added: " + value));
            }
        }

        protected virtual void onBufferRemoved(BufferEventArgs e, T value)
        {
            if (BufferRemoved != null)
            {
                BufferRemoved(this, new BufferEventArgs("_Value was removed: " + value));
            }
        }

        protected virtual void onBufferEmpty(BufferEventArgs e)
        {
            if (BufferEmpty != null)
            {
                // BufferEmpty(this, new BufferEventArgs("_Buffer is empty"));
                try
                {
                    throw new MyBufferException("Buffer is empty");
                }
                catch(MyBufferException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        protected virtual void onBufferFull(BufferEventArgs e)
        {
            if (BufferFull != null)
            {
                // BufferFull(this, new BufferEventArgs("_Buffer is full"));
                try
                {
                    throw new MyBufferException("Buffer is full");
                }
                catch (MyBufferException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class MyNode<T>
    {
       public T Value { get; set; }
       public MyNode <T> Next { get; set; }
        //public MyNode <T> Previous { get; set; }

        public MyNode(T Value)
        {
            this.Value = Value;
        }
    }
}

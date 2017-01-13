using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    interface ISorter<T>:IPrintable<T>
    {
        void Sort();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class Buffer
    {
        protected bool _IsEmpty;
        public virtual bool IsEmpty { get; }
        
        protected bool _IsFull;
        public virtual bool IsFull { get; }

    }
}

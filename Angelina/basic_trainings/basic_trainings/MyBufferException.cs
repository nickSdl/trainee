﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_trainings
{
    class MyBufferException : Exception
    {
        public MyBufferException(string message)
                                 : base(message)
        { }

    }
}

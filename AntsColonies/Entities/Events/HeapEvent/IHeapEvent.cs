﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    interface IHeapEvent
    {
        public ResourcesHeap Target { get; }
    }
}

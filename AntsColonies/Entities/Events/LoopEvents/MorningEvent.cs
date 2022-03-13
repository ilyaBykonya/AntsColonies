using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    class MorningEvent : ILoopEvent
    {
        private bool HandleResultValue = true;
        public bool HandleResult => HandleResultValue;

        public void Accept() => HandleResultValue = true;
        public void Reject() => HandleResultValue = false;
        public override string ToString() => "Morning event";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    class AttackEvent: IHeapEvent
    {
        public ResourcesHeap Target { get; }
        public bool HandleResult => HandleResultValue;
        private bool HandleResultValue = true;

        public AttackEvent(ResourcesHeap target) => Target = target;

        public void Accept() => HandleResultValue = true;
        public void Reject() => HandleResultValue = false;
        public override string ToString() => "Attack event";
    }
}

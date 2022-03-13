using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    class TakeResourcesEvent: IEvent
    {
        public ResourcesHeap Target { get; }
        public bool HandleResult => HandleResultValue;
        private bool HandleResultValue = true;

        public TakeResourcesEvent(ResourcesHeap target) => Target = target;

        public void Accept() => HandleResultValue = true;
        public void Reject() => HandleResultValue = false;
        public override string ToString() => "Take resources event";
    }
}

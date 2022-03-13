using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    class UnitDeathEvent
    {
        public string AntName { get; }
        public BaseAntQueen Owner { get; }
        private bool HandleResultValue = true;
        public bool HandleResult => HandleResultValue;

        public UnitDeathEvent(BaseAntQueen owner, string antName)
        {
            AntName = antName;
            Owner = owner;
        }
        public void Accept() => HandleResultValue = true;
        public void Reject() => HandleResultValue = false;
        public override string ToString() => "Death event";
    }
}

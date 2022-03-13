using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    interface IEvent
    {
        public bool HandleResult{ get; }
        public void Accept();//Вызывается в конце цепочки
        public void Reject();//Вызывается внутри цепочки для прерываний действий
    }
}

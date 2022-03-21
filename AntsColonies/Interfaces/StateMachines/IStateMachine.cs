using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies.Interfaces
{
    interface IStateMachine: IState
    {
        public IState CurrentState { get; set; }
    }
}

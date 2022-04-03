using AntsColonies.Interfaces;
using System.Collections.Generic;

namespace AntsColonies.Units
{
    sealed class GetAttackTargetsQuestion : AbstractQuestion<IEventHandler, IEnumerable<Hiking>>
    {
        public GetAttackTargetsQuestion(IEventHandler answerer) : base(answerer) { }
    }
}

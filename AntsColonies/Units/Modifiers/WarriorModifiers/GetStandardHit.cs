using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    class GetHitQuestion : AbstractQuestion<IEventHandler, BaseFightAction>
    {
        public Location Location { get; }
        public Unit Damager { get; }
        public Unit Target { get; }
        public GetHitQuestion(Location location, Unit damager, Unit target) 
        : base(damager) 
        {
            Location = location;
            Damager = damager;
            Target = target;
        }
    }
    sealed class GetStandardHit : BaseModifier<Unit, GetHitQuestion>
    {
        public GetStandardHit(Unit unit) : base(unit) { }
        public override void HandleEvent(GetHitQuestion e)
        {
            if(e.Damager == Unit)
            {
                int damage = new GetDamageQuestion(Unit).AskQuestion();
                e.Answer = new StandardHitAction(damage, e.Location, e.Damager, e.Target, EventRouter);
            }
           
        }
    }
}


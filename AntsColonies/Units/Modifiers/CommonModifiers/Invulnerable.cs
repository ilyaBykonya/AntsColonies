using AntsColonies.Interfaces;
using AntsColonies.Events;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    class Invulnerable : BaseModifier<Hiking, ReduceHealthNotification>
    {
        public Invulnerable(Hiking unit) : base(unit) { }
        public override void HandleEvent(ReduceHealthNotification e)
        {
            if (e.Target != Unit || e.Location == null || e.Damager is Warrior)
                return;


            Unit.UnitInfo.Health -= e.Damage;
            if (Unit.UnitInfo.Health > 0)
                return;

            Unit.Location = null;
            EventRouter.UnsubscribeSubhandler(Unit);
            EventRouter.HandleEvent(new UnitDeathNotification(Unit));
        }
    }
}


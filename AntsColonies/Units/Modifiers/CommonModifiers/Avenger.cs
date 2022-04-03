using AntsColonies.Interfaces;
using AntsColonies.Events;
using System;

namespace AntsColonies.Units
{
    class Avenger : BaseModifier<Unit, ReduceHealthNotification>
    {
        public Avenger(Unit unit) : base(unit) { }
        public override void HandleEvent(ReduceHealthNotification e)
        {
            if (e.Target != Unit)
                return;

            Unit.UnitInfo.Health -= e.Damage;
            if (Unit.UnitInfo.Health > 0)
                return;

            EventRouter.HandleEvent(new ReduceHealthNotification(e.Damager.UnitInfo.Health, Unit, e.Damager, e.Location));
            Unit.Location = null;
            EventRouter.UnsubscribeSubhandler(Unit);
            EventRouter.HandleEvent(new UnitDeathNotification(Unit));
        }
    }
}


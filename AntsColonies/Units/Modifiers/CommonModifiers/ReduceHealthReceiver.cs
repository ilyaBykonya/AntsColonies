using AntsColonies.Interfaces;
using AntsColonies.Events;
using System;

namespace AntsColonies.Units
{
    class ReduceHealthReceiver : BaseModifier<Unit, ReduceHealthNotification>
    {
        public ReduceHealthReceiver(Unit unit) : base(unit) { }
        public override void HandleEvent(ReduceHealthNotification e)
        {
            if (e.Target != Unit)
                return;

            Unit.UnitInfo.Health -= e.Damage;
            if (Unit.UnitInfo.Health > 0)
                return;

            Unit.Location = null;
            EventRouter.HandleEvent(new UnitDeathNotification(Unit));
        }
    }
}

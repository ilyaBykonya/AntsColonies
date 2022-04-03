using AntsColonies.Interfaces;
using AntsColonies.Events;
using System;


namespace AntsColonies.Units
{
    class Sprinter :
        BaseModifier<Unit, FightProcessAction>,
        IEventHandler<ReduceHealthNotification>,
        IEventHandler<UnitCameToLocation>
    {
        private bool EnabledForAttack = false;
        public Sprinter(Unit unit) : base(unit) { }

        public void HandleEvent(ReduceHealthNotification e)
        {
            if (e.Location == Unit.Location) EnabledForAttack = false;
        }
        public void HandleEvent(UnitCameToLocation e)
        {
            if (e.Unit == Unit) EnabledForAttack = false;
        }
        public override void HandleEvent(FightProcessAction e)
        {
            if (e.Target == Unit && EnabledForAttack == false)
            {
                Console.WriteLine($"[Reject damage from [{e.Damager.Id}] to [{Unit.Id}]]");
                e.Reject();
            }
        }
    }
}

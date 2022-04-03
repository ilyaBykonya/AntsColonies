using AntsColonies.Interfaces;
using AntsColonies.Events;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    class Skinny : BaseModifier<Hiking, ReduceHealthNotification>
    {
        public Skinny(Hiking unit) : base(unit) { }
        public override void HandleEvent(ReduceHealthNotification e)
        {
            if (e.Target != Unit || e.Location == null)
            {
                return;
            }
            if (e is RedirectDamageNotification)
            {
                DamageUnit(e.Damage);
                return;
            }
            var allies = Unit.Location.Units.
                Where(unit => (unit is Hiking) && (unit != Unit)).Select(unit => unit as Hiking).
                Where(unit => new IsMyRelateQuestion(Unit.Queen, unit.Queen).AskQuestion());

            if(allies.Count() == 0)
            {
                DamageUnit(e.Damage);
            }
            else
            {
                EventRouter.HandleEvent(new RedirectDamageNotification(e.Damage, e.Damager, allies.First(), e.Location));
            }
        }
        private void DamageUnit(int damage)
        {
            Unit.UnitInfo.Health -= damage;
            if (Unit.UnitInfo.Health > 0)
                return;

            Unit.Location = null;
            EventRouter.UnsubscribeSubhandler(Unit);
            EventRouter.HandleEvent(new UnitDeathNotification(Unit));
        }
    }
}

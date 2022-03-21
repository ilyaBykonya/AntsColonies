using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;

namespace AntsColonies.Notifications
{
    class BaseReduceHealthNotification : INotification
    {
        public BaseHiking Unit { get; }
        public BaseHiking Damager { get; }
        public virtual int Damage { get; }
        public BaseReduceHealthNotification(BaseHiking unit, BaseHiking damager)
        {
            Damager = damager;
            Unit = unit;
        }
    }
    class DamageNotification: BaseReduceHealthNotification
    {
        public override int Damage { get; }
        public DamageNotification(BaseHiking unit, BaseHiking damager, int damage)
        : base(unit, damager) => Damage = damage;
    }
    class KillNotitfication: BaseReduceHealthNotification
    {
        public override int Damage => Unit.Health;
        public KillNotitfication(BaseHiking unit, BaseHiking damager) : base(unit, damager) { }
    }

    class GetRedirectedDamageNotification: BaseReduceHealthNotification
    {
        public override int Damage { get; }
        public GetRedirectedDamageNotification(BaseHiking unit, BaseHiking damager, int damage)
        : base(unit, damager) => Damage = damage;
    }
}

using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System;

namespace AntsColonies.Events
{
    abstract class FightNotification<DamagerType, TargetType> :
        INotification
        where DamagerType: Unit
        where TargetType: Unit
        {
            public DamagerType Damager { get; }
            public TargetType Target { get; }
            public Location Location { get; }

            protected FightNotification(DamagerType damager, TargetType target, Location location)
            {
                Location = location;
                Damager = damager;
                Target = target;
            }
        }
    
    class ReduceHealthNotification : FightNotification<Unit, Unit>
    {
        public int Damage { get; }
        public ReduceHealthNotification(int damage, Unit damager, Unit target, Location location)
        : base(damager, target, location) => Damage = damage;
    }
    class RedirectDamageNotification : ReduceHealthNotification
    {
        public RedirectDamageNotification(int damage, Unit damager, Unit target, Location location) 
        : base(damage, damager, target, location) { }
    }
}

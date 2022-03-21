using System.Collections.Generic;
using AntsColonies.Notifications;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System;

namespace AntsColonies.Actions
{
    class SimpleAttack: BaseAttack
    {
        public BaseWarrior Damager { get; }
        public SimpleAttack(BaseLocation place, BaseWarrior damager, BaseHiking target)
        : base(place, target) => Voters.Add(Damager = damager);

        public override void ExecuteAction()
        {
            if (VotingResult != true)
                return;

            Console.WriteLine($"Unit damage other unit: [{Damager.UnitId}] => [{Target.UnitId}] = [{(Damager.Damage + 2) / (Target.Armor + 1)}]");
            Target.GlobalNotificator.Notify(new DamageNotification(Target, Damager, (Damager.Damage + 2) / (Target.Armor + 1)));
        }
    }
}

using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Events
{
    abstract class BaseFightAction : BaseAction
    {
        public Location Location { get; }
        public Unit Damager { get; }
        public Unit Target { get; }
        public BaseFightAction(Location location, Unit damager, Unit target, IEventHandler router)
        : base(router)
        {
            Voters.Add(Location = location);
            Voters.Add(Target = target);
            Damager = damager;
        }
    }

    class FightProcessAction : BaseFightAction
    {
        public FightProcessAction(Location location, Unit damager, Unit target, IEventHandler router) 
        : base(location, damager, target, router) { }

        public override void Action()
        {
            Console.WriteLine("*************************");
            Console.WriteLine($"*Fight action: [{Damager.Id}] <=> [{Target.Id}]");
            Console.WriteLine("*************************");

            FightMultiAction hit_damager = new(Location, Damager, Target, EventRouter);
            FightMultiAction hit_target = new(Location, Target, Damager, EventRouter);

            for (int i = 0; i < new GetCountOfHitsQuestion(Damager).AskQuestion(); ++i)
                hit_damager.Hits.Add(new GetHitQuestion(Location, Damager, Target).AskQuestion());
            for (int i = 0; i < new GetCountOfHitsQuestion(Target).AskQuestion(); ++i)
                hit_target.Hits.Add(new GetHitQuestion(Location, Target, Damager).AskQuestion());

            hit_damager.Execute();
            hit_target.Execute();
        }
    }

    class StandardHitAction : BaseFightAction
    {
        public int Damage { get; }
        public StandardHitAction(int damage, Location location, Unit damager, Unit target, IEventHandler router)
        : base(location, damager, target, router) => Damage = damage;

        public override void Action()
        {
            EventRouter.HandleEvent(new ReduceHealthNotification(Damage, Damager, Target, Location));
        }
    }
    class FightMultiAction : BaseFightAction
    {
        public List<BaseFightAction> Hits { get; } = new();
        public FightMultiAction(Location location, Unit damager, Unit target, IEventHandler router)
        : base(location, damager, target, router) { }

        public override void Action() => Hits.ForEach(hit => hit?.Execute());
    }
}

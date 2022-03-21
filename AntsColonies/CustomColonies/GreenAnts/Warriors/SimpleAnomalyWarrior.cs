using AntsColonies.Notifications;
using AntsColonies.Actions;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using AntsColonies.Asks;
using System.Linq;
using System;

namespace AntsColonies.GreenAnts
{
    class SimpleAnomalyWarrior : BaseWarrior
    {
        private class OnAnthillState : BaseHikingOnAnthillState
        {
            protected new readonly SimpleAnomalyWarrior Owner;
            public OnAnthillState(SimpleAnomalyWarrior owner)
            : base(owner) => Owner = owner;

            public override void Notify(INotification notification)
            {
                if (notification is MorningNotification)
                {
                    Owner.GlobalNotificator.Notify(new UnitLeftAnthill(Owner, Anthill));
                    Owner.StateMachine.CurrentState = new OnHeapState(Owner, Owner.ResourceHeapsList.ElementAt(new Random().Next(Owner.ResourceHeapsList.Count)));
                }
                else
                {
                    base.Notify(notification);
                }
            }
            public override void Vote(IVoting voting) => base.Vote(voting);
        }
        private class OnHeapState : BaseHikingOnHeapState
        {
            protected new readonly SimpleAnomalyWarrior Owner;
            public OnHeapState(SimpleAnomalyWarrior owner, Heap heap)
            : base(owner, heap) => Owner = owner;

            public override void Notify(INotification notification)
            {
                if (notification is DayNotification)
                {
                    var onHeapUnits = from unit in Heap.Units
                                      where (unit.Queen.IsMyRelate(Owner.Queen) || unit.Queen == Owner.Queen)
                                      select unit;


                    foreach (var unit in onHeapUnits)
                    {
                        var battle = new BattleRequest(Owner, unit);
                        battle.ExecuteVoting();
                        if (battle.VotingResult == true)
                        {
                            Owner.GlobalNotificator.Notify(new BattleStartNotification(Heap, (Owner, unit)));
                            break;
                        }
                    }
                }
                else if (notification is EveningNotification)
                {
                    Owner.GlobalNotificator.Notify(new UnitLeftHeap(Owner, Heap));
                    Owner.StateMachine.CurrentState = new OnAnthillState(Owner);
                }
                else if (notification is BaseReduceHealthNotification)
                {
                    if (notification is GetRedirectedDamageNotification)
                    {
                        base.Notify(notification);
                        return;
                    }
                    var reduceHealthNotification = notification as BaseReduceHealthNotification;
                    if (reduceHealthNotification.Unit != Owner)
                        return;

                    var alliesUnits = Heap.Units.Where(unit => unit.Queen == Owner.Queen && unit != Owner);
                    if (alliesUnits.Count() > 0)
                    {
                        var allien = alliesUnits.ElementAt(new Random().Next(alliesUnits.Count()));
                        Owner.GlobalNotificator.Notify(new GetRedirectedDamageNotification(allien, reduceHealthNotification.Damager, reduceHealthNotification.Damage));
                    }
                    else
                    {
                        base.Notify(notification);
                    }
                }
                else
                {
                    base.Notify(notification);
                }
            }
            public override void Vote(IVoting voting)
            {
                if (voting is GiveMeYourBeatRequest)
                {
                    var request = (voting as GiveMeYourBeatRequest);
                    request.Hit = new SimpleAttack(request.Location, Owner, request.Target);
                }
                else
                {
                    base.Vote(voting);
                }
            }
        }

        public SimpleAnomalyWarrior(BaseAntQueen queen)
        : base("<[Simple][Anomaly] green warrior>", 1, 0, 1, queen)
        => StateMachine.CurrentState = new OnAnthillState(this);

        public override void Notify(INotification notification) => StateMachine.Notify(notification);
        public override void Vote(IVoting voting) => StateMachine.Vote(voting);
    }
}

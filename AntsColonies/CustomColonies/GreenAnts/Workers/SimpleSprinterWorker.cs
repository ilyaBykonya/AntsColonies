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
    class SimpleSprinterWorker : BaseWorker
    {
        private class OnAnthillState : BaseHikingOnAnthillState
        {
            protected new readonly SimpleSprinterWorker Owner;
            public OnAnthillState(SimpleSprinterWorker owner)
            : base(owner) => Owner = owner;

            public override void Notify(INotification notification)
            {
                if (notification is NightNotification)
                {
                    var voting = new MoveResourcesFromBackpackToStorage(Owner.Backpack, Anthill);
                    voting.ExecuteVoting();
                    voting.ExecuteAction();
                }
                else if (notification is MorningNotification)
                {
                    if (Owner.ResourceHeapsList.Count == 0)
                        return;


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
            private bool EnabledForAttack = false;
            protected new readonly SimpleSprinterWorker Owner;
            public OnHeapState(SimpleSprinterWorker owner, Heap heap)
            : base(owner, heap) => Owner = owner;

            public override void Notify(INotification notification)
            {
                if (notification is DayNotification)
                {
                    Console.WriteLine($"Unit [{Owner.UnitId}] take resources");
                    var voting = new MoveResourcesFromStorageToBackpack(Heap, Owner.Backpack);
                    voting.ExecuteVoting();
                    voting.ExecuteAction();
                }
                else if (notification is EveningNotification)
                {
                    Owner.GlobalNotificator.Notify(new UnitLeftHeap(Owner, Heap));
                    Owner.StateMachine.CurrentState = new OnAnthillState(Owner);
                }
                else if(notification is BaseReduceHealthNotification)
                {
                    EnabledForAttack = true;
                    base.Notify(notification);
                }
                else
                {
                    base.Notify(notification);
                }
            }
            public override void Vote(IVoting voting)
            {
                if(voting is BattleRequest && EnabledForAttack == false)
                {
                    voting.Reject();
                    return;
                }
                base.Vote(voting);
            }
        }


        public SimpleSprinterWorker(BaseAntQueen queen)
        : base("<[Simple][Sprinter] green worker>", 8, 4, queen, new(ResourceCode.Branch, ResourceCode.Stone))
        => StateMachine.CurrentState = new OnAnthillState(this);
    }
}

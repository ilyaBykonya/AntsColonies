using AntsColonies.Notifications;
using AntsColonies.Actions;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.GreenAnts
{
    class AdvancedWorker : BaseWorker
    {
        private class OnAnthillState : BaseHikingOnAnthillState
        {
            protected new readonly AdvancedWorker Owner;
            public OnAnthillState(AdvancedWorker owner)
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
            protected new readonly AdvancedWorker Owner;
            public OnHeapState(AdvancedWorker owner, Heap heap)
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
                else
                {
                    base.Notify(notification);
                }
            }
            public override void Vote(IVoting voting) => base.Vote(voting);
        }


        public AdvancedWorker(BaseAntQueen queen)
        : base("<[Advanced] green worker>", 6, 2, queen, new(ResourceCode.Stone | ResourceCode.Dewdrop, ResourceCode.Stone | ResourceCode.Dewdrop))
        => StateMachine.CurrentState = new OnAnthillState(this);
    }
}

using AntsColonies.Notifications;
using AntsColonies.Actions;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AntsColonies.RedAnts
{
    class AdvancedQueensPet : BaseWorker
    {
        private class OnAnthillState : BaseHikingOnAnthillState
        {
            protected new readonly AdvancedQueensPet Owner;
            public OnAnthillState(AdvancedQueensPet owner)
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

                    //Ищем кучу в которой нет юнитов-воинов
                    var safeHeaps = Owner.ResourceHeapsList.Where(heap => heap.Units.FirstOrDefault(unit => unit is BaseWarrior) == null);
                    if (safeHeaps.Count() == 0)
                        return;

                    var selectedHeap = safeHeaps.ElementAt(new Random().Next(safeHeaps.Count()));
                    Owner.GlobalNotificator.Notify(new UnitLeftAnthill(Owner, Anthill));
                    Owner.StateMachine.CurrentState = new OnHeapState(Owner, selectedHeap);
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
            protected new readonly AdvancedQueensPet Owner;
            public OnHeapState(AdvancedQueensPet owner, Heap heap)
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


        public AdvancedQueensPet(BaseAntQueen queen)
        : base("<[Advanced][Queen's pet] red worker>", 6, 2, queen, new(ResourceCode.Leaf, ResourceCode.Leaf))
        => StateMachine.CurrentState = new OnAnthillState(this);
    }
}

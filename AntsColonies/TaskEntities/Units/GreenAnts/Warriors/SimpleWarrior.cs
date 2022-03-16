using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events.Notifications.TimeLineEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents.CameEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents.GoingEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents.LeaveEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents;
using AntsColonies.Base.Events.VotingEvents.BattleEvents;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.HikingUnits.Warriors;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;


namespace AntsColonies.TaskEntities.Units.GreenAnts.Warriors
{
    class SimpleWarrior: BaseWarrior
    {
        class OnAnthillState : BaseState
        {
            private readonly Anthill Anthill;
            private readonly SimpleWarrior Owner;
            public OnAnthillState(IEventHandler handler, SimpleWarrior owner, Anthill anthill)
            :base(handler)
            {
                Owner = owner;
                Anthill = anthill;
            }

            public override bool HandleEvent(IEvent e)
            {
                switch (e)
                {
                    case MorningEvent:
                        {
                            EventHandler.HandleEvent(new UnitGoingToHeap(Owner));
                            break;
                        }
                    case UnitCameToHeapEvent:
                        {
                            Owner.UnitState = new OnHeapState(EventHandler, Owner, (e as UnitCameToHeapEvent).Target);
                            break;
                        }
                }

                return true;
            }

        }
        class OnHeapState: BaseState
        {
            private readonly ResourcesHeap Heap;
            private readonly SimpleWarrior Owner;
            public OnHeapState(IEventHandler handler, SimpleWarrior owner, ResourcesHeap heap)
            :base(handler)
            {
                Owner = owner;
                Heap = heap;
            }

            public override bool HandleEvent(IEvent e)
            {
                switch (e)
                {
                    case EveninigEvent:
                        {
                            Owner.HandleEvent(new UnitGoingToAnthill(Owner));
                            break;
                        }
                    case UnitCameToAnthillEvent:
                        {
                            Owner.UnitState = new OnAnthillState(EventHandler, Owner, (e as UnitCameToAnthillEvent).Target);
                            break;
                        }
                    case DayEvent:
                        {
                            //Вместо null найти какого-нибудь петушка на куче
                            Owner.HandleEvent(new BaseAttackEvent(Heap, Owner, null));
                            break;
                        }
                    case BaseAttackEvent attackVote:
                        {
                            attackVote.Accept();
                            break;
                        }
                }

                return true;
            }
        }

        protected IEventHandler Handler { get; }
        public SimpleWarrior(YoungAntQueen queen, IEventHandler handler)
        : base(queen, "Simple", 1, 0, 1) => Handler = handler;
    }
}

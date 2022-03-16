using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events.Notifications.MovementEvents.CameEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents.GoingEvents;
using AntsColonies.Base.Events.Notifications.ResourceEvents;
using AntsColonies.Base.Events.Notifications.TimeLineEvents;
using AntsColonies.Base.Events.Notifications.LifeCycleEvents;
using AntsColonies.Base.Events.VotingEvents.ResourceEvents;
using AntsColonies.Base.Events.VotingEvents.BattleEvents;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.HikingUnits.Workers;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.TaskEntities.Units.GreenAnts.Workers
{
    class SimpleSprinterWorker: BaseWorker
    {
        class OnAnthillState : BaseState
        {
            private readonly Anthill Anthill;
            private readonly BaseWorker Owner;
            public OnAnthillState(IEventHandler handler, BaseWorker owner, Anthill anthill)
            : base(handler)
            {
                Anthill = anthill;
                Owner = owner;
            }

            public override bool HandleEvent(IEvent e)
            {
                switch (e)
                {
                    case NightEvent:
                        {
                            List<ResourceCell> puttedResource = new();
                            for (Resource resource = Owner.Backpack.TakeCell(); resource != null; resource = Owner.Backpack.TakeCell())
                                puttedResource.Add(new ResourceCell(resource));

                            EventHandler.HandleEvent(new UnitPutResource(puttedResource, Owner));
                            break;
                        }
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
        class OnHeapState : BaseState
        {
            private bool EnableForAttack = false;
            private readonly ResourcesHeap Heap;
            private readonly BaseWorker Owner;
            public OnHeapState(IEventHandler handler, BaseWorker owner, ResourcesHeap heap)
            : base(handler)
            {
                Owner = owner;
                Heap = heap;
            }

            public override bool HandleEvent(IEvent e)
            {
                switch (e)
                {
                    case DayEvent:
                        {
                            EventHandler.HandleEvent(new TakeResourcesEvent(Heap, Owner));
                            break;
                        }
                    case EveninigEvent:
                        {
                            EventHandler.HandleEvent(new UnitGoingToAnthill(Owner));
                            break;
                        }
                    case UnitTakeResource:
                        {
                            (e as UnitTakeResource).Resources.ForEach(cell => Owner.Backpack.PutResource(cell.TakeResource()));
                            break;
                        }
                    case UnitCameToAnthillEvent:
                        {
                            Owner.UnitState = new OnAnthillState(EventHandler, Owner, (e as UnitCameToAnthillEvent).Target);
                            break;
                        }
                    case BaseAttackEvent:
                        {
                            var attackEvent = e as BaseAttackEvent;
                            if(attackEvent.TargetHeap == Heap)
                            {
                                if(attackEvent.Target == Owner)
                                {
                                    if(EnableForAttack == true)
                                        attackEvent.Accept();
                                    else
                                        attackEvent.Reject();
                                }
                                else
                                {
                                    EnableForAttack = true;
                                }
                            }
                            break;
                        }
                }

                return true;
            }
        }


        public SimpleSprinterWorker(YoungAntQueen queen, IEventHandler handler)
        : base(queen, "Simple sprinter", 1, 0, new(ResourceCode.Leaf)) { }
    }
}

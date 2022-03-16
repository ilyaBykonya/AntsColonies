using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events.Notifications.LifeCycleEvents;
using AntsColonies.Base.Events.Notifications.TimeLineEvents;
using AntsColonies.Base.Events.Notifications.ResourceEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents.LeaveEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents.GoingEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents.CameEvents;
using AntsColonies.Base.Events.Notifications.BattleEvents;
using AntsColonies.Base.Events.Notifications.MovementEvents;
using AntsColonies.Base.Events.VotingEvents.ResourceEvents;
using AntsColonies.Base.Events.VotingEvents.BattleEvents;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Base.Units.HikingUnits.Workers
{
    /*
     Вообще, неплохо бы добавить какой-нибудь супер-пупер-умный
     алгоритм взятия ресурсов из кучи, но решать задачу о рюкзаке
     мне точно лень, так что будет просто жадный алгоритм.
     */
    class WorkerBackpack : IResourceStorage
    {
        private ResourceCell[] Cells { get; }
        public WorkerBackpack(params ResourceCode[] types)
        {
            Cells = new ResourceCell[types.Length];
            for (int index = 0; index < types.Length; ++index)
                Cells[index] = new ResourceCell(types[index]);
        }
        public void PutResource(Resource resource)
        {
            foreach (var cell in Cells)
                if (cell.PutResource(resource))
                    return;

            throw new InvalidOperationException("Cannot put " + resource.Type + " in this backpack");
        }
        public Resource TakeCell(ResourceCode resource = (ResourceCode)15)
        {
            for (int index = 0; index < Cells.Length; ++index)
                if (Cells[index].HasResource && ((Cells[index].ValidResources | resource) != 0))
                    return Cells[index].TakeResource();
                
            throw new InvalidOperationException("Cannot take " + resource + " from this backpack");
        }
    }

    abstract class BaseWorker : BaseHikingUnit
    {
        protected class BaseWorkerOnAnthillState: BaseHikingOnAnthillState
        {
            protected readonly BaseWorker Owner;
            public BaseWorkerOnAnthillState(IEventHandler handler, BaseWorker owner, Anthill anthill)
            : base(handler, anthill) => Owner = owner;

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
                    case UnitLeaveAnthillEvent:
                        {
                            var leaveEvent = e as UnitLeaveAnthillEvent;
                            if (leaveEvent.Unit == Owner)
                                Owner.UnitState = new BaseWorkerOnHikingState(EventHandler, Owner);

                            break;
                        }
                }
                return true;
            }
        }
        protected class BaseWorkerOnHeapState : BaseHikingOnHeapState
        {
            protected readonly BaseWorker Owner;
            public BaseWorkerOnHeapState(IEventHandler handler, BaseWorker owner, ResourcesHeap heap)
            :base(handler, heap) => Owner = owner;
            

            public override bool HandleEvent(IEvent e)
            {
                switch (e)
                {
                    case DayEvent:
                        {
                            EventHandler.HandleEvent(new TakeResourcesEvent(Heap, Owner));
                            break;
                        }
                    case UnitTakeResource:
                        {
                            var takeEvent = e as UnitTakeResource;
                            if (takeEvent.Unit == Owner)
                                takeEvent.Resources.ForEach(cell => Owner.Backpack.PutResource(cell.TakeResource()));

                            break;
                        }
                    case EveninigEvent:
                        {
                            EventHandler.HandleEvent(new UnitGoingToAnthill(Owner));
                            break;
                        }
                    case UnitLeaveHeapEvent:
                        {
                            var leaveEvent = e as UnitLeaveHeapEvent;
                            if (leaveEvent.Unit == Owner)
                                Owner.UnitState = new BaseWorkerOnHikingState(EventHandler, Owner);

                            break;
                        }
                    case BaseAttackEvent:
                        {
                            e.Accept();
                            break;
                        }
                    case BaseDamageNotification:
                        {
                            EventHandler.HandleEvent(new UnitDeathEvent(Owner));
                            break;
                        }
                }

                return true;
            }
        }
        protected class BaseWorkerOnHikingState : BaseHikingOnHikingState
        {
            protected readonly BaseWorker Owner;
            public BaseWorkerOnHikingState(IEventHandler handler, BaseWorker owner)
            :base(handler) => Owner = owner;

            public override bool HandleEvent(IEvent e)
            {
                switch (e)
                {
                    case UnitCameToAnthillEvent:
                        {
                            var cameEvent = e as UnitCameToAnthillEvent;
                            if (cameEvent.Unit == Owner)
                                Owner.UnitState = new BaseWorkerOnAnthillState(EventHandler, Owner, cameEvent.Target);

                            break;
                        }
                    case UnitCameToHeapEvent:
                        {
                            var cameEvent = e as UnitCameToHeapEvent;
                            if(cameEvent.Unit == Owner)
                                Owner.UnitState = new BaseWorkerOnHeapState(EventHandler, Owner, cameEvent.Target);

                            break;
                        }
                }

                return true;
            }
        }


        public WorkerBackpack Backpack { get; }
        public override bool HandleEvent(IEvent e) => UnitState.HandleEvent(e);
        protected BaseWorker(YoungAntQueen queen, string name, int health, int armor, WorkerBackpack backpack)
        : base(queen, name, health, armor) => Backpack = backpack;
    }
}

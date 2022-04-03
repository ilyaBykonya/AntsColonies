using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Linq;
using System;

namespace AntsColonies.Colonies.SongCicade
{
    class SongCicade : SimulationActor
    {
        class SongCicadeInFly : IEventHandler, IEventHandler<NightNotification>
        {
            private int Days;
            private SongCicade Owner { get; }
            public SongCicadeInFly(int days, SongCicade owner)
            {
                Owner = owner;
                Days = new Random().Next(days - 2);
                Owner.EventRouter.HandleEvent(new SubscribeActor(Owner));
            }

            public void HandleEvent(IEvent e)
            {
                if (e is NightNotification)
                    HandleEvent(e as NightNotification);
            }
            public void HandleEvent(NightNotification e)
            {
                if(--Days <= 0)
                {
                    Owner.StateMachine = new SongCicadeOnHeap(Owner);
                }
            }
        }
        class SongCicadeOnHeap : IEventHandler, IEventHandler<FightProcessAction>, IEventHandler<NightNotification>
        {
            private int Days = 2;
            private SongCicade Owner { get; }
            private Heap Heap { get; }
            public SongCicadeOnHeap(SongCicade owner)
            {
                Owner = owner;
                Heap = Owner.Simulation.Heaps.ElementAt(new Random().Next(Owner.Simulation.Heaps.Count));
                Heap?.SubscribeSubhandler(this);
            }

            public void HandleEvent(IEvent e)
            {
                if (e is FightProcessAction)
                    HandleEvent(e as FightProcessAction);
                if (e is NightNotification)
                    HandleEvent(e as NightNotification);
            }
            public void HandleEvent(FightProcessAction e)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------Fight rejected----------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("---------------------------------------------------------");
                e.Reject();
            }
            public void HandleEvent(NightNotification e)
            {
                if (Days-- > 0)
                    return;

                Heap?.UnsubscribeSubhandler(this);
                Owner.StateMachine = new SongCicadeDeath(Owner);
            }
        }
        class SongCicadeDeath : IEventHandler 
        {
            private SongCicade Owner { get; }
            public SongCicadeDeath(SongCicade owner)
            {
                Owner = owner;
                Owner.EventRouter.HandleEvent(new UnsubscribeActor(Owner));
            }
            public void HandleEvent(IEvent e) { } 
        }

        private IEventHandler StateMachine;
        public SongCicade(int days, Simulation simulation)
        : base(simulation) => StateMachine = new SongCicadeInFly(days, this);
        public override void HandleEvent(IEvent e) => StateMachine?.HandleEvent(e);
    }
}

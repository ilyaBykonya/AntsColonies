using System.Collections;
using System.Collections.Generic;
using AntsColonies.Notifications;
using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Actions;
using AntsColonies.Units;
using AntsColonies.Asks;
using System.Linq;
using System;

namespace AntsColonies.SongCicade
{
    class SongCicade : IEventHandler
    {
        private class SongCicadeStateMachine
        {
            public IState CurrentState { get; set; }
            public void Notify(INotification notification) => CurrentState?.Notify(notification);
            public void Vote(IVoting voting) => CurrentState?.Vote(voting);
        }
        private class WaitState: IState
        {
            public SongCicade Owner { get; }
            public Heap Target { get; }
            public int RemainedDaysBeforeCame { get; protected set; }
            public WaitState(SongCicade owner, HashSet<Heap> heaps, int daysBeforeDought)
            {
                RemainedDaysBeforeCame = new Random().Next(1, daysBeforeDought - 1);
                Target = heaps.ElementAt(new Random().Next(heaps.Count));
                Owner = owner;
            }

            public void Vote(IVoting voting) { }
            public void Notify(INotification notification)
            {
                if(notification is NightNotification)
                {
                    --RemainedDaysBeforeCame;
                    if (RemainedDaysBeforeCame <= 0)
                        Owner.StateMachine.CurrentState = new WorkState(Owner, Target);
                }
            }
        }
        private class WorkState: IState
        {
            public SongCicade Owner { get; }
            public Heap Target { get; }
            public int RemainedDaysBeforeDeath { get; protected set; } = 2;
            public WorkState(SongCicade owner, Heap target)
            {
                Owner = owner;
                Target = target;
                Target.Subhandlers.Add(Owner);
            }

            public void Vote(IVoting voting) 
            {
                switch(voting)
                {
                    case BaseAttack:
                        {
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("Reject attack");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                            voting.Reject();
                            break;
                        }
                }
            }
            public void Notify(INotification notification)
            {
                if (notification is NightNotification)
                {
                    --RemainedDaysBeforeDeath;
                    if (RemainedDaysBeforeDeath <= 0)
                    {
                        Target.Subhandlers.Remove(Owner);
                        Owner.StateMachine.CurrentState = new DeathState();
                    }
                }
            }
        }
        private class DeathState : IState
        {
            public void Notify(INotification notification) { }
            public void Vote(IVoting voting) { }
        }


        public bool IsWorked { get; protected set; } = false;
        private SongCicadeStateMachine StateMachine { get; } = new();

        public SongCicade(HashSet<Heap> heaps, int daysBeforeDought) => StateMachine.CurrentState = new WaitState(this, heaps, daysBeforeDought);



        public void Notify(INotification notification) => StateMachine.Notify(notification);
        public void Vote(IVoting voting) => StateMachine.Vote(voting);
    }
}

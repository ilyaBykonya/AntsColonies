using AntsColonies.Interfaces;
using AntsColonies.Units;
using System;

namespace AntsColonies.Events
{
    class SubscribeActor : INotification
    {
        public SimulationActor Actor { get; }
        public SubscribeActor(SimulationActor actor) => Actor = actor;
    }
    class UnsubscribeActor : INotification
    {
        public SimulationActor Actor { get; }
        public UnsubscribeActor(SimulationActor actor) => Actor = actor;
    }


    sealed class UnitBornedNotification : SubscribeActor
    {
        public Unit Unit { get; }
        public UnitBornedNotification(Unit unit) : base(unit) => Unit = unit;
    }
    sealed class UnitDeathNotification : UnsubscribeActor
    {
        public Unit Unit { get; }
        public UnitDeathNotification(Unit unit) : base(unit) => Unit = unit;
    }
}

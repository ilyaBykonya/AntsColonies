using AntsColonies.Interfaces;
using AntsColonies.Units;
using System;

namespace AntsColonies.Events
{
    sealed class UnitBornedNotification : INotification
    {
        public Unit Unit { get; }
        public UnitBornedNotification(Unit unit) => Unit = unit;
    }
    sealed class UnitDeathNotification : INotification
    {
        public Unit Unit { get; }
        public UnitDeathNotification(Unit unit) => Unit = unit;
    }
}

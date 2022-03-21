using AntsColonies.Interfaces;
using AntsColonies.Units;

namespace AntsColonies.Notifications
{
    class LifeCycleNotification<T>: INotification 
    where T: BaseUnit
    {
        public T Unit { get; }
        public LifeCycleNotification(T unit) => Unit = unit;
    }

    class UnitBornedNotification : LifeCycleNotification<BaseUnit>
    {
        public UnitBornedNotification(BaseUnit unit) : base(unit) { }
        public override string ToString() => $"Unit borned [{Unit.UnitId}]";
    }
    class UnitDeathNotification : LifeCycleNotification<BaseUnit>
    {
        public UnitDeathNotification(BaseUnit unit) : base(unit) { }
        public override string ToString() => $"Unit death [{Unit.UnitId}]";
    }
    class QueenBanishedFromAnthill: LifeCycleNotification<BaseAntQueen>
    {
        public QueenBanishedFromAnthill(BaseAntQueen unit) : base(unit) { }
        public override string ToString() => $"Queen banned from anthill [{Unit.UnitId}]";
    }
    class QueenDeathNotification : LifeCycleNotification<BaseAntQueen>
    {
        public QueenDeathNotification(BaseAntQueen unit) : base(unit) { }
        public override string ToString() => $"Queen death [{Unit.UnitId}]";
    }
}

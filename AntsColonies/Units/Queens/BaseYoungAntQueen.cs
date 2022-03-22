using System.Collections.Generic;
using System;


namespace AntsColonies.Units
{
    abstract class BaseYoungAntQueen : BaseAntQueen
    {
        public BaseAdultAntQueen Parent { get; }
        public override bool IsMyRelate(BaseAntQueen other) => other.Children.Contains(this);
        public BaseYoungAntQueen(string name, int health, int armor, List<Type> childrenTypes, BaseAdultAntQueen parent)
        : base(name, armor, health, parent.ResourceHeapsList, parent.GlobalNotificator, childrenTypes, parent.LarvalGrowthTimeRange, parent.NumberOfLarvaeRange)
        => Parent = parent;
    }
}

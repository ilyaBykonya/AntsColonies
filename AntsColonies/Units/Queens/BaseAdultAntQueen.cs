using AntsColonies.Interfaces;
using AntsColonies.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies.Units
{
    abstract class BaseAdultAntQueen : BaseAntQueen
    {
        public override bool IsMyRelate(BaseAntQueen other) => Children.Contains(other);
        public BaseAdultAntQueen(string name, int health, int armor, HashSet<Heap> heaps, INotificationReceiver notificator, List<Type> childrenTypes, (int, int) growthTime, (int, int) numberOfLarvae) 
        :base(name, armor, health, heaps, notificator, childrenTypes, growthTime, numberOfLarvae) { }
    }
}

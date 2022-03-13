using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    abstract class BaseHiking: BaseInsect
    {
        public int Armor { get; }
        public BaseHiking(int health, int armor) :base(health) => Armor = armor;
    }
}

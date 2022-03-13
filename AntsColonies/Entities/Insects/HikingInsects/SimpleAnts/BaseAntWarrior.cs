using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies
{
    abstract class BaseAntWarrior: BaseHiking
    {
        public int Damage { get; }
        public BaseAntWarrior(int health, int armor, int damage) : base(health, armor) => Damage = damage;
    }
}

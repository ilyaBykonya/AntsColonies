namespace AntsColonies
{
    abstract class BaseHiking: BaseInsect
    {
        public int Armor { get; }
        public BaseHiking(int health, int armor) :base(health) => Armor = armor;
    }
}

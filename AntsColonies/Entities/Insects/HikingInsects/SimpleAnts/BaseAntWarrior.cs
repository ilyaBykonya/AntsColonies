namespace AntsColonies
{
    abstract class BaseAntWarrior: BaseHiking
    {
        public int Damage { get; }
        public BaseAntWarrior(int health, int armor, int damage) : base(health, armor) => Damage = damage;
    }
}

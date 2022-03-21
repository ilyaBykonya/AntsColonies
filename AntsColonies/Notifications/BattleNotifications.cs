using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;

namespace AntsColonies.Notifications
{
    class BattleStartNotification: INotification
    {
        public BaseLocation Location { get; }
        public (BaseHiking, BaseHiking) Units { get; }
        public BattleStartNotification(BaseLocation location, (BaseHiking, BaseHiking) units)
        {
            Location = location;
            Units = units;
        }
    }
}

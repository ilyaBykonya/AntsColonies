using AntsColonies.Interfaces;
using AntsColonies.Events;

namespace AntsColonies.Units
{
    class WalkOnHomeInTheEvening :
        BaseModifier<Hiking, EveningNotification>,
        IEventHandler<EveningNotification>
    {
        public WalkOnHomeInTheEvening(Hiking unit) : base(unit) { }
        public override void HandleEvent(EveningNotification e) => Unit.Location = Unit.Queen.QueenInfo.Anthill;
    }
}

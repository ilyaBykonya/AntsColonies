using AntsColonies.Base.Events.VotingEvents.BattleEvents;

namespace AntsColonies.Base.Events.AdvancedTask
{
    class SongCicade : IEventHandler
    {
        public bool HandleEvent(Base.Events.IEvent e)
        {
            bool checkResult = e is BaseAttackEvent;
            if (checkResult == false)
                e.Reject();

            return checkResult;
        }
    }
}

namespace AntsColonies
{
    class SongCicada : IEventHandler
    {
        public void HandleEvent(IEvent e)
        {
            if (e is AttackEvent)
                e.Reject();
            else
                e.Accept();
        }
    }
}

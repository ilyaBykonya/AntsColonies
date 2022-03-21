using AntsColonies.Notifications;
using AntsColonies.Interfaces;

namespace AntsColonies.Locations
{
    class Anthill : BaseLocation
    {
        public Anthill() : base(new()) { }

        public override void Notify(INotification notification)
        {
            if(notification is UnitCameToAnthill) 
            {
                var resultNotify = notification as UnitCameToAnthill;
                if (resultNotify.Target == this)
                {
                    Units.Add(resultNotify.Unit);
                }
                else
                {
                    return;
                }
            } 
            else if(notification is UnitLeftAnthill)
            {
                var resultNotify = notification as UnitLeftAnthill;
                if (resultNotify.Target == this)
                {
                    Units.Remove(resultNotify.Unit);
                }
                else
                {
                    return;
                }
            }

            foreach (var handler in Subhandlers)
                handler.Notify(notification);
        }
        public override void Vote(IVoting voting)
        {
            foreach (var unit in Units)
                unit.Vote(voting);
            foreach (var handler in Subhandlers)
                handler.Vote(voting);
        }
    }
}

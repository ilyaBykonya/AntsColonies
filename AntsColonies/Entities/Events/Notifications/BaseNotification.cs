using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Events.Notifications
{
    class BaseNotification : IEvent
    {
        public bool HandleResult => true;

        public void Accept() { }
        public void Reject() { }
    }
}

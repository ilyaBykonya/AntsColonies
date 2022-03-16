using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events.Notifications;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Events.Notifications.BattleEvents
{
    class BaseDamageNotification: BaseNotification
    {
        public BaseHikingUnit Attacking { get; }
        public BaseHikingUnit Target { get; }

        public BaseDamageNotification(BaseHikingUnit attacking, BaseHikingUnit target)
        {
            Attacking = attacking;
            Target = target;
        }
    }
}

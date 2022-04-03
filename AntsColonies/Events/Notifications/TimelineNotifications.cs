using AntsColonies.Interfaces;
using System;

namespace AntsColonies.Events
{
    abstract class TimelineNotifications: INotification { }

    sealed class MorningNotification : TimelineNotifications { }
    sealed class DayNotification : TimelineNotifications { }
    sealed class EveningNotification : TimelineNotifications { }
    sealed class NightNotification : TimelineNotifications { }
}

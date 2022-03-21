using AntsColonies.Interfaces;

namespace AntsColonies.Notifications
{
    class TimelineNotifications: INotification { }

    class MorningNotification : TimelineNotifications { }
    class DayNotification : TimelineNotifications { }
    class EveningNotification : TimelineNotifications { }
    class NightNotification : TimelineNotifications { }
}

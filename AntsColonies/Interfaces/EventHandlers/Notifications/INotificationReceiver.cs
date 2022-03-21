using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsColonies.Interfaces
{
    interface INotificationReceiver
    {
        public void Notify(INotification notification);
    }
    interface INotificationReceiver<T> where T: INotification
    {
        public void Notify(T notification);
    }
}

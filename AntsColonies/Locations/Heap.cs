using System.Collections.Generic;
using System.Linq;
using System;
using AntsColonies.Notifications;
using AntsColonies.Interfaces;

namespace AntsColonies.Locations
{
    class Heap : BaseLocation
    {
        public Heap(LinkedList<Resource> resources) : base(resources) { }

        public override void Notify(INotification notification)
        {
            if (notification is UnitCameToHeap) 
            {
                var resultNotify = notification as UnitCameToHeap;
                if (resultNotify.Target == this)
                {
                    Units.Add(resultNotify.Unit);
                }
                else
                {
                    return;
                }
            }
            else if (notification is UnitLeftHeap) 
            {
                var resultNotify = notification as UnitLeftHeap;
                if (resultNotify.Target == this)
                {
                    Units.Remove(resultNotify.Unit);
                }
                else
                {
                    return;
                }
            }
            else if(notification is NightNotification)
            {
                Console.WriteLine("========Resource heap==========");
                int branches = Resources.Count(resource => resource.Type == ResourceCode.Branch);
                int leafs = Resources.Count(resource => resource.Type == ResourceCode.Leaf);
                int stones = Resources.Count(resource => resource.Type == ResourceCode.Stone);
                int dewdrop = Resources.Count(resource => resource.Type == ResourceCode.Dewdrop);
                Console.WriteLine($"[{branches}, {leafs}, {stones}, {dewdrop}]");
                Console.WriteLine("===============================");
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

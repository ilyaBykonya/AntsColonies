using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Events
{
    class MoveResourcesBetweenStorages : BaseAction
    {
        private IResourceStorage Source { get; }
        private IResourceStorage Destination { get; }
        public MoveResourcesBetweenStorages(IResourceStorage source, IResourceStorage destination, IEventRouter router)
        :base(router)
        {
            Voters.Add(Destination = destination);
            Voters.Add(Source = source);
        }
        public override void Action()
        {
            Console.WriteLine($"[Move resource from <{Source.GetType().Name}> to <{Destination.GetType().Name}>]");
            foreach (var required in Destination.RequiredResources)
            {
                for (int index = 0; index < required.Value; ++index)
                {
                    var resource = Source.TakeResource(required.Key);
                    if (resource is null)
                        break;

                    Console.WriteLine($"\t{resource}");
                    if (Destination.PutResource(resource) == false)
                        throw new InvalidOperationException("Invalid storage");
                }
            }
        }
    }
}

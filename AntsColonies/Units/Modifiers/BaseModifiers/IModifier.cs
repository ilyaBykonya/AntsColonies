using AntsColonies.Interfaces;
using System;

namespace AntsColonies.Units
{
    interface IModifier : IEventHandler
    {
        Guid EventGuid { get; }
    }
}

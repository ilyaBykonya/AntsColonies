using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Base.Units
{
    abstract class BaseUnit : IEventHandler
    {
        public string Name { get; }
        public int Health { get; protected set; }
        public BaseUnit(string name, int health)
        {
            Name = name;
            Health = health;
        }
        public abstract bool HandleEvent(IEvent e);
    }
}

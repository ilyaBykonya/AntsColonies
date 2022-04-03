using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Green
{
    class SprinterWorker : Worker
    {
        public SprinterWorker(Queen queen)
        : base(new(ResourceCode.Leaf), new("<Simple><Sprinter><Green><Worker>", 1, 0, 0), queen) 
        {

        }
    }
}


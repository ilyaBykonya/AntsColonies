using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Green
{
    class EliteWorker : Worker
    {
        public EliteWorker(Queen queen) 
        : base(new(ResourceCode.Branch, ResourceCode.Stone), new("<Elite><Green><Worker>", 8, 0, 4), queen) { }
    }
}

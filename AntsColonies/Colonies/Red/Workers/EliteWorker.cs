using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Red
{
    class EliteWorker : Worker
    {
        public EliteWorker(Queen queen)
        : base(new(ResourceCode.Branch, ResourceCode.Branch), new("<Elite><Red><Worker>", 8, 0, 4), queen) { }
    }
}


using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Red
{
    class AdvancedWorker : Worker
    {
        public AdvancedWorker(Queen queen)
        : base(new(ResourceCode.Dewdrop | ResourceCode.Stone, ResourceCode.Dewdrop | ResourceCode.Stone), new("<Advanced><Red><Worker>", 6, 0, 2), queen) { }
    }
}



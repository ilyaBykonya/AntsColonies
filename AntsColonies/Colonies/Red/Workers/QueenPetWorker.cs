using AntsColonies.Interfaces;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Colonies.Red
{
    class QueenPetWorker : Worker
    {
        public QueenPetWorker(Queen queen)
        : base(new(ResourceCode.Dewdrop | ResourceCode.Stone, ResourceCode.Dewdrop | ResourceCode.Stone), new("<Advanced><Queen pet><Red><Worker>", 6, 0, 2), queen)
        {
            InstallModifier(new QueenPet(this));
        }
    }
}

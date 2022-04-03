using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Units
{
    sealed class LayLarvae : BaseModifier<Queen, MorningNotification>
    {
        public LayLarvae(Queen unit) : base(unit) { }
        public override void HandleEvent(MorningNotification e)
        {
            Unit.UninstallModifier(EventGuid);
            Unit.InstallModifier(new TakeCareLarvae(Unit));
        }
    }
}

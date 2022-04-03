using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Units
{
    abstract class IsMyRelateAnswerer : BaseModifier<Queen, IsMyRelateQuestion>
    {
        public IsMyRelateAnswerer(Queen unit) : base(unit) { }
    }
    sealed class AdultQueenIsMyRelateAnswerer : IsMyRelateAnswerer
    {
        public AdultQueenIsMyRelateAnswerer(Queen unit) : base(unit)  { }
        public override void HandleEvent(IsMyRelateQuestion e)
        {
            if (e.Answerer == Unit) 
                e.Answer = (Unit.QueenInfo.Children.Contains(e.Questioner) || Unit == e.Questioner);
        }
    }
    sealed class YoungQueenIsMyRelateAnswerer : IsMyRelateAnswerer
    {
        public YoungQueenIsMyRelateAnswerer(Queen unit) : base(unit)  { }
        public override void HandleEvent(IsMyRelateQuestion e)
        {
            if (e.Answerer == Unit)
                e.Answer = (e.Questioner.QueenInfo.Children.Contains(Unit) || Unit == e.Questioner);
        }
    }
}

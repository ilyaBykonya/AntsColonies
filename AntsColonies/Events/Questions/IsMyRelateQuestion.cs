using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Events
{
    class IsMyRelateQuestion : AbstractQuestion<Queen, bool>
    {
        public Queen Questioner { get; }
        public IsMyRelateQuestion(Queen questioner, Queen answerer) 
        :base(answerer) => Questioner = questioner;
    }
}

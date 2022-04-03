using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;


namespace AntsColonies.Colonies.Green
{
    class AdultGreenQueen : AdultQueen
    {
        public AdultGreenQueen(Simulation simulation) 
        : base(new(new(new() { /*typeof(EliteWorker), typeof(SimpleWarrior),*/typeof(AnomalyWarrior), typeof(YoungGreenQueen) }, (1, 4), (2, 4)), new("<Adult><Green><Queen><Victory>", 28, 28, 9)), simulation) { }
    }
    class YoungGreenQueen : YoungQueen
    {
        public YoungGreenQueen(AdultQueen parent) 
        : base(new(new(new() { /*typeof(EliteWorker), typeof(SimpleWarrior),*/typeof(AnomalyWarrior) }, (1, 4), (2, 4)), new("<Adult><Green><Queen><Young>", 28, 28, 9)), parent) { }
    }
}

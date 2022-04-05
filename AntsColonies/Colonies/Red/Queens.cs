using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;


namespace AntsColonies.Colonies.Red
{
    class AdultRedQueen : AdultQueen
    {
        public AdultRedQueen(Simulation simulation)
        : base(new(new(new() { typeof(EliteWorker), typeof(QueenPetWorker), typeof(AdvancedWorker), typeof(AdvancedWarrior), typeof(LegendaryWarrior), typeof(SkinnyWarrior), typeof(YoungRedQueen) }, (1, 4), (1, 3)), new("<Adult><Red><Queen><Mary>", 25, 24, 9)), simulation) { }
    }
    class YoungRedQueen : YoungQueen
    {
        public YoungRedQueen(AdultQueen parent)
        : base(new(new(new() { typeof(EliteWorker), typeof(QueenPetWorker), typeof(AdvancedWorker), typeof(AdvancedWarrior), typeof(LegendaryWarrior), typeof(SkinnyWarrior) }, (1, 4), (1, 3)), new("<Adult><Red><Queen><Young>", 25, 24, 9)), parent) { }
    }
}

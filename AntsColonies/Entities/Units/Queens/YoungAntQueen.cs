using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;


namespace AntsColonies.Base.Units.Queens
{
    //Это как королева, но у неё нет дочерей-королев
    class YoungAntQueen: BaseUnit
    {
        public Anthill OwnAnthill { get; } = new();

        public YoungAntQueen(string name, int health) : base(name, health) { }
        public override bool HandleEvent(IEvent e)
        {
            //Тут королева обрабатывает события...пока не обрабатывает
            throw new NotImplementedException();
        }
    }
}

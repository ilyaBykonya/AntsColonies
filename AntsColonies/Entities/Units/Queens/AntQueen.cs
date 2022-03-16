using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Base.Units.Queens
{
    class AntQueen: YoungAntQueen, IEnumerable<YoungAntQueen>
    {
        protected LinkedList<YoungAntQueen> Children { get; } = new();

        public AntQueen(string name, int health) : base(name, health) { }
        public override bool HandleEvent(IEvent e)
        {
            //Тут королева обрабатывает события...пока не обрабатывает
            throw new NotImplementedException();
        }
        public IEnumerator<YoungAntQueen> GetEnumerator() => Children.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
    }
}

using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.HikingUnits;
using AntsColonies.Base.Units.HikingUnits.Workers;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.TaskEntities.Units.RedAnts.Workers
{
    class QueensFavouriteWorker: BaseWorker
    {
        /*
         * Вот тут прописать, что если на куче, куда его хотят отправить, есть враги, он откажется туда топать.
         */

        public QueensFavouriteWorker(YoungAntQueen queen, IEventHandler handler)
        : base(queen, "Advanced queen's favourite", 6, 2, new(ResourceCode.Leaf, ResourceCode.Leaf)) { }
    }
}

﻿using AntsColonies.Base.Locations;
using AntsColonies.Base.Resources;
using AntsColonies.Base.States;
using AntsColonies.Base.Events;
using AntsColonies.Base.Units.Queens;
using AntsColonies.Base.Units;
using System.Collections.Generic;
using System;

namespace AntsColonies.Base.Locations
{
    class Anthill : IResourceStorage
    {
        protected LinkedList<ResourceCell> ResourceStorage = new();
        public void PutResource(Resource resource) => ResourceStorage.AddLast(new ResourceCell(resource));
        public Resource TakeCell(ResourceCode resource = (ResourceCode)15)
        {
            foreach(var cell in ResourceStorage)
            {
                if((cell.ValidResources | resource) != 0 && cell.HasResource)
                {
                    ResourceStorage.Remove(cell);
                    return cell.TakeResource(); ;
                }
            }
            throw new InvalidOperationException("Cannot take " + resource + " from this anthill");
        }
        //========================================================
    }
}

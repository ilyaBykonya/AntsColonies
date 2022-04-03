using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Units
{
    record QueenParameters(List<Type> ChildrenTypes, (int, int) GrowthTime, (int, int) NumberOfLarvae);
    sealed class QueenInfo
    {
        public HashSet<Unit> Children { get; } = new();
        public Anthill Anthill { get; }

        public QueenInfo(Anthill anthill) => Anthill = anthill;
    }
    
    abstract class Queen : Unit
    {
        public QueenInfo QueenInfo { get; }
        public QueenParameters QueenParameters { get; }
        public Queen((QueenParameters, QueenInfo, UnitInfo) info, Simulation simulation)
        : base(info.Item3, info.Item2.Anthill, simulation)
        {
            QueenInfo = info.Item2;
            QueenParameters = info.Item1;
            InstallModifier(new LayLarvae(this));
        }
    }
    abstract class AdultQueen : Queen
    {
        public AdultQueen((QueenParameters, UnitInfo) info, Simulation simulation) 
        : base(new(info.Item1, new(new(simulation.EventRouter)), info.Item2), simulation)
        {
            InstallModifier(new AdultQueenIsMyRelateAnswerer(this));
        }
    }
    abstract class YoungQueen : Queen
    {
        public AdultQueen Parent { get; }
        public YoungQueen((QueenParameters, UnitInfo) info, AdultQueen parent)
        : base(new(info.Item1, new(new(parent.EventRouter)), info.Item2), parent.Simulation)
        {
            Parent = parent;
            InstallModifier(new YoungQueenIsMyRelateAnswerer(this));
        }
    }
}

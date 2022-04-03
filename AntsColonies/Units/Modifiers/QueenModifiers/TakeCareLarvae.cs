using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace AntsColonies.Units
{
    sealed class TakeCareLarvae : BaseModifier<Queen, EveningNotification>
    {
        public int RemainedDays { get; set; }
        public int CountOfLarvae { get; }
        public TakeCareLarvae(Queen unit) : base(unit)
        {
            RemainedDays = new Random().Next(unit.QueenParameters.GrowthTime.Item1, unit.QueenParameters.GrowthTime.Item2);
            CountOfLarvae = new Random().Next(unit.QueenParameters.NumberOfLarvae.Item1, unit.QueenParameters.NumberOfLarvae.Item2);
        }

        public override void HandleEvent(EveningNotification e)
        {
            --RemainedDays;
            if (RemainedDays > 0)
                return;

            Random generator = new();
            for (int i = 0; i < CountOfLarvae; ++i)
            {
                
                var newUnit = (Unit)Activator.CreateInstance(Unit.QueenParameters.ChildrenTypes.ElementAt(generator.Next(Unit.QueenParameters.ChildrenTypes.Count)), Unit);
                Console.WriteLine($"Queen born new unit [{Unit.Id}] => [{newUnit.Id}]");
                Unit.QueenInfo.Children.Add(newUnit);
            }

            Unit.UninstallModifier(EventGuid);
            Unit.InstallModifier(new LayLarvae(Unit));
        }
    }
}

using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Events;
using AntsColonies.Units;
using System.Collections.Generic;
using System.Collections;
using System;

namespace AntsColonies.Units
{
    sealed class UnitInfo
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Armor { get; set; }
        
        public UnitInfo(string name, int health, int damage, int armor)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Armor = armor;
        }
    }
    abstract class Unit : SimulationActor
    {
        //==========================================
        private Location LocationValue;
        public Location Location
        {
            get => LocationValue;
            set
            {
                if (LocationValue is not null) { EventRouter.HandleEvent(new UnitLeftLocation(this, LocationValue)); }
                LocationValue = value;
                if (LocationValue is not null) { EventRouter.HandleEvent(new UnitCameToLocation(this, LocationValue)); }
            }
        }
        //==========================================
        public UnitInfo UnitInfo { get; }
        //==========================================

        public Unit(UnitInfo info, Location location, Simulation simulation) 
        : base(simulation)
        {
            UnitInfo = info;
            Location = location;
            InstallModifier(new ReduceHealthReceiver(this));
            EventRouter.HandleEvent(new UnitBornedNotification(this));
        }
        private Dictionary<Guid, IModifier> Modifiers { get; } = new();
        public void InstallModifier(IModifier modifier)
        {
            if (Modifiers.ContainsKey(modifier.EventGuid))
            {
                UnsubscribeSubhandler(Modifiers[modifier.EventGuid]);
                Modifiers[modifier.EventGuid] = modifier;
            }
            else
            {
                Modifiers.Add(modifier.EventGuid, modifier);
            }

            SubscribeSubhandler(modifier);
        }
        public void UninstallModifier(Guid id)
        {
            var modifier = Modifiers.GetValueOrDefault(id);
            if(modifier is not null)
            {
                UnsubscribeSubhandler(modifier);
                Modifiers.Remove(id);
            }
        }
    }
}

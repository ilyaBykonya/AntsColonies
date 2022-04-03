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
        private static int GlobalUnitId = 0;
        public int Id { get; } = ++GlobalUnitId;
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
        private Dictionary<Guid, IModifier> Modifiers { get; } = new();
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
        public sealed override void HandleEvent(IEvent e) => Modifiers.GetValueOrDefault(e.GetType().GUID)?.HandleEvent(e);
        public void UninstallModifier(Guid id) => Modifiers.Remove(id);
        public void InstallModifier(IModifier modifier)
        {
            if (Modifiers.TryAdd(modifier.EventGuid, modifier) == false)
                Modifiers[modifier.EventGuid] = modifier;
        }
    }
}

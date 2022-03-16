namespace AntsColonies.Base.Events
{
    interface IEventHandler//цепочка обязанностей...своеобразная, но пусть будет
    {
        public bool HandleEvent(IEvent e);
    }
}

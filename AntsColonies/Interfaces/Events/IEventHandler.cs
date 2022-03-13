namespace AntsColonies
{
    interface IEventHandler//цепочка обязанностей...своеобразная, но пусть будет
    {
        public void HandleEvent(IEvent e);
    }
}

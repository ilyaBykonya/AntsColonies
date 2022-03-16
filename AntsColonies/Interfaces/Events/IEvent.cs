namespace AntsColonies.Base.Events
{
    interface IEvent
    {
        public bool HandleResult{ get; }
        public void Accept();
        public void Reject();
    }
}

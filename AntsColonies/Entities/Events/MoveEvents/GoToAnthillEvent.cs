namespace AntsColonies
{
    class GoToAnthillEvent : IMoveEvent
    {
        public BaseHiking Owner { get; }
        private bool HandleResultValue = true;
        public bool HandleResult => HandleResultValue;

        public GoToAnthillEvent(BaseHiking owner) => Owner = owner;
        
        public void Accept() => HandleResultValue = true;
        public void Reject() => HandleResultValue = false;
        public override string ToString() => "Go to anthill event";
    }
}

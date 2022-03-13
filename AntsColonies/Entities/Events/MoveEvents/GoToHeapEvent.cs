namespace AntsColonies
{
    class GoToHeapEvent: IMoveEvent
    {
        public BaseHiking Owner { get; }
        private bool HandleResultValue = true;
        public bool HandleResult => HandleResultValue;

        public GoToHeapEvent(BaseHiking owner) => Owner = owner;

        public void Accept() => HandleResultValue = true;
        public void Reject() => HandleResultValue = false;
        public override string ToString() => "Go to heap event";
    }
}

namespace AntsColonies
{
    class DayEvent : ILoopEvent
    {
        private bool HandleResultValue = true;
        public bool HandleResult => HandleResultValue;

        public void Accept() => HandleResultValue = true;
        public void Reject() => HandleResultValue = false;
        public override string ToString() => "Day event";
    }
}

namespace AntsColonies
{
    class UnitBirthEvent : ILifeCycleEvents
    {
        public string AntName { get; }
        public BaseAntQueen Owner { get; }
        private bool HandleResultValue = true;
        public bool HandleResult => HandleResultValue;

        public UnitBirthEvent(BaseAntQueen owner, string antName)
        {
            AntName = antName;
            Owner = owner;
        }
        public void Accept() => HandleResultValue = true;
        public void Reject() => HandleResultValue = false;
        public override string ToString() => "Birth event";
    }
}

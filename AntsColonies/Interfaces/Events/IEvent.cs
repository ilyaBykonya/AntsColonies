namespace AntsColonies
{
    interface IEvent
    {
        public bool HandleResult{ get; }
        public void Accept();//Вызывается в конце цепочки
        public void Reject();//Вызывается внутри цепочки для прерываний действий
    }
}

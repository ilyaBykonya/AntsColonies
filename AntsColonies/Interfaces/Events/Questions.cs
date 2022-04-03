namespace AntsColonies.Interfaces
{
    interface IQuestion : IEvent { }
    interface IQuestion<ResultType, AnswererType> : IQuestion where AnswererType : IEventHandler
    {
        public AnswererType Answerer { get; }
        public ResultType? Answer { get; }
        public ResultType? AskQuestion();
    }
    class AbstractQuestion<AnswererType, ResultType> : 
        IQuestion<ResultType, AnswererType>
        where AnswererType : IEventHandler
    {
        public AnswererType Answerer { get; }
        public ResultType? Answer { get; set; }
        public AbstractQuestion(AnswererType answerer) => Answerer = answerer;
        public ResultType? AskQuestion()
        {
            Answerer.HandleEvent(this);
            return Answer;
        }
    }
}

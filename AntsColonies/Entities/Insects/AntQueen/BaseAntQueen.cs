using System;
using System.Collections.Generic;
namespace AntsColonies
{
    class BaseAntQueen: IEventHandler
    {
        class QueenLaysLarvaeState : IState
        {
            private BaseAntQueen Owner;
            public QueenLaysLarvaeState(BaseAntQueen owner) => Owner = owner;

            public void HandleEvent(IEvent e)
            {
                if (e is MorningEvent)
                    Owner.AntQueenState = new QueenTakeCareOfLarvaeState(Owner);

                e.Accept();
            }
        }
        class QueenTakeCareOfLarvaeState : IState
        {
            private BaseAntQueen Owner;
            public ushort remainedGrowthTime { get; protected set; }
            public ushort currentLarvals { get; }
            public QueenTakeCareOfLarvaeState(BaseAntQueen owner)
            {
                Owner = owner;

                Random rand = new Random();
                currentLarvals = (ushort)rand.Next(Owner.MaximalBornLarvasRange.Item1, Owner.MaximalBornLarvasRange.Item2 + 1);
                remainedGrowthTime = (ushort)rand.Next(Owner.MaximalLarvasGrowthTime.Item1, Owner.MaximalLarvasGrowthTime.Item2 + 1);
            }

            public void HandleEvent(IEvent e)
            {
                if(e is EveningEvent)
                {
                    if(remainedGrowthTime > 0)
                        --remainedGrowthTime;

                    if (remainedGrowthTime == 0)
                    {
                        for (int i = 0; i < currentLarvals; ++i)
                            Owner.GlobalEventHandler.HandleEvent(new UnitBirthEvent(Owner, "Some ant"));

                        Owner.AntQueenState = new QueenLaysLarvaeState(Owner);
                    }
                }
            }
        }


        public Anthill Home { get; }
        private IState AntQueenState;
        public IEventHandler GlobalEventHandler { get; set; }
        public (ushort, ushort) MaximalBornLarvasRange { get; }
        public (ushort, ushort) MaximalLarvasGrowthTime { get; }

        public BaseAntQueen((ushort, ushort) bornLarval, (ushort, ushort) growthTime)
        {
            Home = new(this);
            MaximalBornLarvasRange = bornLarval;
            MaximalLarvasGrowthTime = growthTime;

            AntQueenState = new QueenLaysLarvaeState(this);
        }

        public void HandleEvent(IEvent e)
        {
            if(e is ILoopEvent)
                AntQueenState.HandleEvent(e);
        }
    }
}

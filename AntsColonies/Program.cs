using System;
using System.Collections.Generic;

/*
 * Для синхронизации действий сутки разделены на 4 части:
 * 1. [Утро]:  Войска и работники разбиваются на группы и шагают на рудники.
 * 2. [День]:  Работники раотают, войска воюют.
 * 3. [Вечер]: Войска и работники идут назад.
 * 4. [Ночь]:  Вывод на экраны текущего глобального состояния. Личинки вырастают и королева откладывает новые.
 */

namespace AntsColonies
{
    /*
    class ApplicationEventLoop
    {
        private int daysBeforeDrought = 0;
        LinkedList<Pile> pilesList = new();
        LinkedList<AntQueen> queensList = new();
        LinkedList<WalkerInsect> walkersList = new();

        public ApplicationEventLoop()
        {
            daysBeforeDrought = 12;

            pilesList.AddLast(new Pile(new Resources(0, 35, 42, 46)));
            pilesList.AddLast(new Pile(new Resources(49, 0, 20, 33)));
            pilesList.AddLast(new Pile(new Resources(0, 23, 0, 36)));
            pilesList.AddLast(new Pile(new Resources(0, 32, 13, 22)));
            pilesList.AddLast(new Pile(new Resources(35, 34, 22, 19)));

            queensList.AddLast(new AntQueen((5, 7)));
            queensList.Last.Value.OnBorned += NewInsectBorned;
        }


        private void NewInsectBorned(AntQueen parent, WalkerInsect insect) => walkersList.AddLast(insect);


        public void executeSimulation()
        {
            for(int i = 0; (i < daysBeforeDrought) && (queensList.Count > 0); ++i)
            {
                morning();
                day();
                evening();
                night();
            }
        }
        private void morning() { Console.WriteLine("morning"); }
        private void day() { Console.WriteLine("day"); }
        private void evening() { Console.WriteLine("evening"); }
        private void night() { Console.WriteLine("night"); }
    }
    */
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, world");
        }
    }
}

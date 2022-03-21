using AntsColonies.Interfaces;
using AntsColonies.Locations;
using AntsColonies.Units;
using AntsColonies;
using System.Collections.Generic;
using System;

/*
 * Для синхронизации действий сутки разделены на 4 части:
 * 1. [Утро]:  Войска и работники разбиваются на группы и шагают на рудники.
 * 2. [День]:  Работники раотают, войска воюют.
 * 3. [Вечер]: Войска и работники идут назад.
 * 4. [Ночь]:  Вывод на экраны текущего глобального состояния. Личинки вырастают и королева откладывает новые.
 */
using System.Net;
using System.IO;

namespace AntsColonies
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("===============Start application==========");
            ApplicationExecutor executor = new();
            executor.ExecuteSimulation();
            executor.PrintSimulatingResult();
            Console.WriteLine("===============Finish application=========");
        }
    }
}

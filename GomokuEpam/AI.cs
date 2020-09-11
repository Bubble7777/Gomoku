using System;

namespace GomokuEpam
{
    /// <summary>
    /// Создаем защенный поля имя, Символ(Х-0), цвет символа!
    /// </summary>
   public class AI
    {
        internal string Name { get; private set; }
        internal string Symbol { get; private set; }
        internal ConsoleColor Color { get; private set; }
        public AI(string name, string symbol, ConsoleColor color)
        {
            Name = name;
            Symbol = symbol;
            Color = color;
        }
    }
}

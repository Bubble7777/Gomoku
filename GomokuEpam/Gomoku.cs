using System;

namespace GomokuEpam
{
   public class Gomoku
    {
        /// <summary>
        /// Создаем двумерный массив доску
        /// </summary>
        private string[,] Board;

        /// <summary>
        /// объявляем  экзампляры Ai
        /// </summary>
        private AI AIOne;
        private AI AITwo;

        private AI lastStepAI;

        /// <summary>
        /// Создаем метод StartGame() в котором идет инициализация доски, двух игроков.
        /// </summary>
        public void StartGame()
        {
            // инициализируем двумерный массив доска и заполняем двумерный массив знаком "_"
            Board = new string[15, 15];
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    Board[i, j] = " _ ";
                }

            }

            // инициализируем экземпляры AI
            AIOne = new AI("AI One", "X", ConsoleColor.Green);
            AITwo = new AI("AI Two", "O", ConsoleColor.Red);

            while (true)
            {
                if (lastStepAI == null)
                {
                    lastStepAI = AIOne;
                    Step(AIOne);                  
                }
                else
                {
                    if (lastStepAI == AIOne)
                    {
                        if (Step(AITwo))
                        {
                            Console.WriteLine("AI Two Win!!");
                            break;
                        }                       
                        lastStepAI = AITwo;
                    }   
                    else
                    {
                        if (Step(AIOne))
                        {
                            Console.WriteLine("AI one Win!");
                            break;
                        }
                        lastStepAI = AIOne;
                    }
                }
            } 
        }
     
       // метод Step который принимает AI(One или Two) и ставит рандомно символы этих игроков
       
        private bool Step(AI AI)
        {
            Console.Clear();

            Random random = new Random();

            int x = random.Next(0, 15);
            int y = random.Next(0, 15);

            while(Board[x,y] == lastStepAI.Symbol)
            {
                x = random.Next(0, 15);
                y = random.Next(0, 15);
            }
            
            Board[x, y] = AI.Symbol;
            
            PrintBoard();
            // проверка на проверку
            if (Check(x,y,AI))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// метод проверки по сторонам доски
        private bool Check(int x, int y,AI AI)
        {
            int MinXNum = 0;
            int MaxXNum = 0;
            int count = 0;
            if (x > 4)
            {
                MinXNum = x - 4;
                if (x + 4 > 10)
                {
                    MaxXNum = 10;
                }
                else
                {
                    MaxXNum = x + 4;
                }
            }
            else
            {
                MaxXNum = x + 4;
            }

            int MinYNum = 0;
            int MaxYNum = 0;
            if (y > 4)
            {
                MinYNum = y - 4;
                if (y + 4 > 10)
                {
                    MaxYNum = 10;
                }
                else
                {
                    MaxYNum = y + 4;
                }
            }
            else
            {
                MaxYNum = y + 4;
            }
            //проверка по горизонтали

            for (int i = MinXNum; i < MaxXNum + 1; i++)
            {
                if (Board[i,y] == AI.Symbol)
                {
                    count++;
                    if (count > 4)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                    if (i > MaxXNum - 4)
                    {
                        break;
                    }
                }
            }

            // проверка по вертикали

            for (int i = MinYNum; i < MaxYNum + 1; i++)
            {
                if (Board[x, i] == AI.Symbol)
                {
                    count++;
                }
                else
                {
                    count = 0;
                    if (i > MaxYNum - 4)
                    { 
                        break;
                    }                     
                }
                if (count > 4)
                {
                    return true;
                }
            }

            // проверка левого диагональ 
            for (int i = MinXNum; i < MaxXNum + 1; i++)
            {
                if (x + y - i < 0)
                {
                    break;
                }
                if (x + y - i <= 10)
                {
                    if (Board[i, x + y - i] == AI.Symbol)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                        if (i > MaxXNum - 4)
                        {
                            break;
                        }
                    }
                }
                if (count > 4)
                {
                    return true;
                }
            }
            // проверка правого диагональ 
            for (int i = MinXNum; i < MaxXNum + 1; i++)
            {
                if (i < x - y)
                {
                    break;
                }
                if (i + y - x > 10)
                {
                    break;
                }
                if (Board[i, i + y -x] == AI.Symbol)
                {
                    count++;
                }
                else
                {
                    count = 0;
                    if (i > MaxYNum - 4)
                    {
                        break;
                    }
                }
                if (count > 4)
                {
                    return true;
                }
            }
            return false;
        }

        // метод вывода доски и символов
        private void PrintBoard()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (Board[i,j] == AIOne.Symbol)
                    {
                        Console.ForegroundColor = AIOne.Color;
                        Console.Write("{0,3}", Board[i, j]);
                    }
                    else if (Board[i,j] == AITwo.Symbol)
                    {
                        Console.ForegroundColor = AITwo.Color;
                        Console.Write("{0,3 }", Board[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("{0,3}", Board[i,j]);
                    }
                }
                Console.WriteLine();
            }
            
        }

    }
}

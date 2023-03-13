using System;

namespace Brave_new_world
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlayng = true;

            int playerPositionX;
            int playerPositionY;
            int directionX = 0, directionY = 0;
            int allPoints;
            int collect = 0;

            char[,] map;
            char player = '@';

            Console.CursorVisible = false;

            map = ReadMap(out playerPositionY, out playerPositionX, out allPoints,player);
            
            DrawMap(map);

            Console.SetCursorPosition(playerPositionY, playerPositionX);
            Console.Write(player);

            while (isPlayng)
            {
                ConsoleUI(collect, allPoints);

                Move(map, ref playerPositionX, ref playerPositionY, directionX, directionY,player);

                collectingPoints(map, playerPositionX, playerPositionY, ref collect);

                if (collect == allPoints)
                {
                    isPlayng = false;
                }

                ConsoleUI(collect, allPoints);  
            }
        }

        private static void ConsoleUI(int collectPoints,int allPoints)
        {
            int positionY = 15;

            Console.SetCursorPosition(0, positionY);
            Console.WriteLine($"Собрано {collectPoints}/{allPoints}");

            if (collectPoints == allPoints)
            {
                Console.SetCursorPosition(0, positionY);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вы попедили!!!!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static char[,] ReadMap(out int playerPositionX, out int playerPositionY, out int allPoints,char player)
        {
            char symbol = ' ';
            char point = '.';
            
            playerPositionX = 1;
            playerPositionY = 1;
            allPoints = 0;
   
            char[,] map =
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#','#','#','#','#','#','#',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#','#','#','#','#','#','#',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#','#','#','#','#','#','#',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#','#','#','#','#','#','#',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#','#','#','#','#','#','#',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#','#','#','#','#','#','#',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#','#','#','#','#','#','#',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ','#','#','#','#',' ','#','#',' ',' ',' ',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#'},
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#'},
            };
            
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == player)
                    {
                        playerPositionX = i;
                        playerPositionY = j;
                    }
                    if (map[i, j] == symbol)
                    {
                        map[i, j] = point;
                        allPoints++;
                    }
                }
            }

            return map;
        }

        private static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(map[i, j]);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }
        }

        private static void Move(char[,] map, ref int playerPositionX, ref int playerPositionY, int directionY, int directionX,char player)
        {
            char grid = '#';

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        directionX = -1; directionY = 0;
                        break;

                    case ConsoleKey.DownArrow:
                        directionX = 1; directionY = 0;
                        break;

                    case ConsoleKey.LeftArrow:
                        directionX = 0; directionY = -1;
                        break;

                    case ConsoleKey.RightArrow:
                        directionX = 0; directionY = 1;
                        break;
                }

                if (map[playerPositionX + directionX, playerPositionY + directionY] != grid)
                {
                    Console.SetCursorPosition(playerPositionY, playerPositionX);
                    Console.Write(" ");

                    playerPositionX += directionX;
                    playerPositionY += directionY;

                    Console.SetCursorPosition(playerPositionY, playerPositionX);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(player);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        private static void collectingPoints(char[,] map, int playerPositionX, int playerPositionY, ref int collect)
        {
            char point = '.';
            char whitespace = ' ';

            if (map[playerPositionX, playerPositionY] == point)
            {
                collect++;

                map[playerPositionX, playerPositionY] = whitespace;
            }
        }
    }
}

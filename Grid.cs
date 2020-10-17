using System;
using System.Linq;
using System.Threading;

namespace grid
{
    public class Grid
    {   
        private char[,] grid;

        public char Player
        {get; set;}

        public char Point
        {get; set;}

        public int Score
        {get; private set;}

        private Timer objTimer
        {get; set;}
        private int Timer
        {get; set;}
        
        public void Display()
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(grid[i,j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("     SCORE:  " + Score);
            Console.WriteLine("     TIMER:  " + Timer);
        }

        public Grid(char player, char point)
        {
            grid = new char[,]
            {
                {'X', '1', '2', '3', '4', '5', '6', '7', '8', '9'},
                {'A', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'B', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'C', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'D', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'E', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'F', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'G', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'H', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'I', '-', '-', '-', '-', '-', '-', '-', '-', '-'}
            };

            this.Timer = 5;
            this.Player = player;
            this.Point = point;
        }

        private void Callback(Object stateInfo)
        {
            Timer--;
            Update();
        }

        public Grid() : this('O', '+')
        {
        }

        public void Play()
        {
            this.objTimer = new Timer(Callback, null, 1000, 1000);
            
            var random = new Random();
            int row;
            int col;
            
            row = random.Next(1, 10);
            col = random.Next(1, 10);

            grid[row,col] = Player;
            SpawnPoint();
            Update();
        }
        
        private void SpawnPoint(int amount = 1)
        {
            var random = new Random();
            int row;
            int col;
            
            for (int i = 1; i <= amount; i++)
            {
                do
                {
                    row = random.Next(1, 10);
                    col = random.Next(1, 10);
                }
                while (grid[row,col] != '-');

                grid[row,col] = Point;
            }
        }
        
        private void Update()
        {
            bool noPoints = true;

            if (Timer == 0)
            {
                objTimer.Dispose();
                GameOver();
            }
            
            foreach (var c in grid)
            {
                if (c == Point)
                {
                    noPoints = false;
                    break;
                }
            }

            if (noPoints)
            {
                Score++;
                Timer = 5;
                SpawnPoint(Score/5 + 1);
            }

            Display();
            
            var dirInput = Console.ReadKey().Key;
            string dirString = null;
            switch (dirInput)
            {
                case ConsoleKey.Escape:
                    return;
                case ConsoleKey.W:
                    dirString = "up";
                    break;
                case ConsoleKey.S:
                    dirString = "down";
                    break;
                case ConsoleKey.A:
                    dirString = "left";
                    break;
                case ConsoleKey.D:
                    dirString = "right";
                    break;
                default:
                    dirString = "null";
                    break;
            }

            Move(dirString);
        }
        
        public void Set(char r, char c, char x)
        {            
            switch (char.ToUpper(r))
            {
                case 'A':
                case '1':
                    grid[1, Int32.Parse(c.ToString())] = x;
                    break;
                case 'B':
                case '2':
                    grid[2, Int32.Parse(c.ToString())] = x;
                    break;
                case 'C':
                case '3':
                    grid[3, Int32.Parse(c.ToString())] = x;
                    break;
                case 'D':
                case '4':
                    grid[4, Int32.Parse(c.ToString())] = x;
                    break;
                case 'E':
                case '5':
                    grid[5, Int32.Parse(c.ToString())] = x;
                    break;
                case 'F':
                case '6':
                    grid[6, Int32.Parse(c.ToString())] = x;
                    break;
                case 'G':
                case '7':
                    grid[7, Int32.Parse(c.ToString())] = x;
                    break;
                case 'H':
                case '8':
                    grid[8, Int32.Parse(c.ToString())] = x;
                    break;
                case 'I':
                case '9':
                    grid[9, Int32.Parse(c.ToString())] = x;
                    break;
                default:
                    break;
            }
        }

        public void Clear()
        {
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    grid[i,j] = '-';
                }
            }
        }

        public void Move(string dir)
        {
            bool playerFound = false;
            int playerColumn = 0;
            int playerRow = 0;

            for (int i = 1; i < 10; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    if (grid[i,j] == Player)
                    {
                        playerRow = i;
                        playerColumn = j;
                        playerFound = true;
                        break;
                    }
                }
                if (playerFound) {break;}
            }

            int newRow = playerRow;
            int newColumn = playerColumn;
            bool invalid = false;
            switch (dir.ToLower())
            {
                case "up":
                case "u":
                    newRow--;
                    break;
                case "down":
                case "d":
                    newRow++;
                    break;
                case "left":
                case "l":
                    newColumn--;
                    break;
                case "right":
                case "r":
                    newColumn++;
                    break;
                default:
                    invalid = true;
                    break;
            }
            
            if (newRow > 9 || newRow < 1 || newColumn > 9 || newColumn < 1)
            {
                invalid = true;
            }
            
            if (!invalid)
            {
                grid[playerRow, playerColumn] = '-';
                grid[newRow, newColumn] = Player;
            }
            Update();
        }

        public void GameOver()
        {
            Display();
            Console.WriteLine(" / / / GAME OVER!!! \\ \\ \\");
            Console.WriteLine($"   / / / SCORE: {Score} \\ \\ \\");
            System.Environment.Exit(0);
        }
    }
}
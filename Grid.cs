using System;
using System.Linq;
using System.Threading;

namespace grid
{
    public class Grid
    {   
        private char[] columnNums = new char[] {'X', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
        private char[] rowA;
        private char[] rowB;
        private char[] rowC;
        private char[] rowD;
        private char[] rowE;
        private char[] rowF;
        private char[] rowG;
        private char[] rowH;
        private char[] rowI;
        private char[][] rows;

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
            foreach (var row in rows)
            {
                Console.WriteLine(string.Join("  ", row));
            }
            Console.WriteLine("     SCORE:  " + Score);
            Console.WriteLine("     TIMER:  " + Timer);
        }

        public Grid(char player, char point)
        {
            rowA = new char[]
            {'A', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            rowB = new char[]
            {'B', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            rowC = new char[]
            {'C', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            rowD = new char[]
            {'D', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            rowE = new char[]
            {'E', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            rowF = new char[]
            {'F', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            rowG = new char[]
            {'G', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            rowH = new char[]
            {'H', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            rowI = new char[]
            {'I', '-', '-', '-', '-', '-', '-', '-', '-', '-'};

            rows = new char[][]
            {columnNums, rowA, rowB, rowC, rowD,
            rowE, rowF, rowG, rowH, rowI};

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

            rows[row][col] = Player;
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
                while (rows[row][col] != '-');

                rows[row][col] = Point;
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
            
            foreach (var row in rows)
            {
                if (row.Contains<char>(Point))
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
                    rowA[Int32.Parse(c.ToString())] = x;
                    break;
                case 'B':
                case '2':
                    rowB[Int32.Parse(c.ToString())] = x;
                    break;
                case 'C':
                case '3':
                    rowC[Int32.Parse(c.ToString())] = x;
                    break;
                case 'D':
                case '4':
                    rowD[Int32.Parse(c.ToString())] = x;
                    break;
                case 'E':
                case '5':
                    rowE[Int32.Parse(c.ToString())] = x;
                    break;
                case 'F':
                case '6':
                    rowF[Int32.Parse(c.ToString())] = x;
                    break;
                case 'G':
                case '7':
                    rowG[Int32.Parse(c.ToString())] = x;
                    break;
                case 'H':
                case '8':
                    rowH[Int32.Parse(c.ToString())] = x;
                    break;
                case 'I':
                case '9':
                    rowI[Int32.Parse(c.ToString())] = x;
                    break;
                default:
                    break;
            }
        }

        public void Clear()
        {
            for (int j = 1; j <= 9; j++)
            {
                for (int i = 1; i <= 9; i++)
                {
                    rows[j][i] = '-';
                }
            }
        }

        public void Move(string dir)
        {
            bool playerFound = false;
            int playerColumn = 0;
            int playerRow = 0;

            for (int j = 1; j <= 9; j++)
            {
                for (int i = 1; i <= 9; i++)
                {
                    if (rows[j][i] == Player)
                    {
                        playerRow = j;
                        playerColumn = i;
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
                rows[playerRow][playerColumn] = '-';
                rows[newRow][newColumn] = Player;
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
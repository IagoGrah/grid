using System;

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

        private bool IsMoveMode
        {get; set;}
        
        public char Player
        {get; set;}

        public char Point
        {get; set;}

        public int Score
        {get; private set;}
        
        public void Display()
        {
            Console.Clear();
            foreach (var row in rows)
            {
                Console.WriteLine(string.Join("  ", row));
            }
            if (IsMoveMode)
            {
                Console.WriteLine("     SCORE:  " + Score);
            }
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

            this.IsMoveMode = false;
            this.Player = player;
            this.Point = point;
        }

        public Grid() : this('O', '+')
        {
        }

        public void MoveMode()
        {
            IsMoveMode = true;
            
            var random = new Random();
            int row;
            int col;
            
            row = random.Next(1, 10);
            col = random.Next(1, 10);

            rows[row][col] = Player;
            SpawnPoint();
        }
        
        private void SpawnPoint()
        {
            var random = new Random();
            int row;
            int col;
            
            do
            {
                row = random.Next(1, 10);
                col = random.Next(1, 10);
            }
            while (rows[row][col] != '-');

            rows[row][col] = Point;
        }
        
        private void Update(bool gotPoint)
        {
            if (gotPoint)
            {
                Score++;
                SpawnPoint();
            }
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
                    break;
            }
            
            if (newRow > 9 || newRow < 1 || newColumn > 9 || newColumn < 1)
            {
                return;
            }
            
            bool gotPoint = false;
            
            if (rows[newRow][newColumn] == Point) {gotPoint = true;}
            rows[playerRow][playerColumn] = '-';
            rows[newRow][newColumn] = Player;
            Update(gotPoint);
        }
    }
}
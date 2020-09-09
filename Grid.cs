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
        
        public void Display()
        {
            Console.Clear();
            foreach (var row in rows)
            {
                Console.WriteLine(string.Join("  ", row));
            }
            
        }

        public Grid()
        {
            this.rowA = new char[]
            {'A', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            this.rowB = new char[]
            {'B', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            this.rowC = new char[]
            {'C', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            this.rowD = new char[]
            {'D', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            this.rowE = new char[]
            {'E', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            this.rowF = new char[]
            {'F', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            this.rowG = new char[]
            {'G', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            this.rowH = new char[]
            {'H', '-', '-', '-', '-', '-', '-', '-', '-', '-'};
            this.rowI = new char[]
            {'I', '-', '-', '-', '-', '-', '-', '-', '-', '-'};

            this.rows = new char[][]
            {this.columnNums, this.rowA, this.rowB, this.rowC, this.rowD,
            this.rowE, this.rowF, this.rowG, this.rowH, this.rowI};
        }

        public void Set(char r, char c, char x)
        {            
            switch (char.ToUpper(r))
            {
                case 'A':
                    this.rowA[Int32.Parse(c.ToString())] = x;
                    break;
                case 'B':
                    this.rowB[Int32.Parse(c.ToString())] = x;
                    break;
                case 'C':
                    this.rowC[Int32.Parse(c.ToString())] = x;
                    break;
                case 'D':
                    this.rowD[Int32.Parse(c.ToString())] = x;
                    break;
                case 'E':
                    this.rowE[Int32.Parse(c.ToString())] = x;
                    break;
                case 'F':
                    this.rowF[Int32.Parse(c.ToString())] = x;
                    break;
                case 'G':
                    this.rowG[Int32.Parse(c.ToString())] = x;
                    break;
                case 'H':
                    this.rowH[Int32.Parse(c.ToString())] = x;
                    break;
                case 'I':
                    this.rowI[Int32.Parse(c.ToString())] = x;
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
                    this.rows[j][i] = '-';
                }
            }
        }
    }
}
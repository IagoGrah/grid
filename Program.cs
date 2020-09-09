using System;

namespace grid
{
    class Program
    {
        static void Main(string[] args)
        {
            var myGrid = new Grid();
            
            while (true)
            {
                myGrid.Display();
                
                // Get coordinates
                Console.WriteLine("INSERT COORDINATES (i.e. B5):");
                var coordInput = Console.ReadLine();
                
                if (coordInput.ToLower() == "exit")
                {break;}
                if (coordInput.ToLower() == "clear")
                {myGrid.Clear(); continue;}

                if (coordInput.Length != 2)
                {
                    Console.WriteLine("Invalid Input!");
                    continue;
                }            
                var coord = coordInput.ToCharArray();
                if (!Int32.TryParse(coord[1].ToString(), out int num))
                {
                    Console.WriteLine("Invalid Column!");
                    continue;
                }
                if (num < 1 || num > 9)
                {
                    Console.WriteLine("Invalid Column!");
                    continue;
                }

                // Get input char
                Console.WriteLine("INSERT CHARACTER:");
                var letterInput = Console.ReadLine();
                if (!Char.TryParse(letterInput, out char letter))
                {
                    Console.WriteLine("Invalid Character!");
                    continue;
                }

                // Display grid with user input
                myGrid.Set(coord[0], coord[1], letter);
            }
        }
    }
}

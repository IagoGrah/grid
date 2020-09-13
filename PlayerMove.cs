using System;

namespace grid
{
    class PlayerMove
    {
        static void Main(string[] args)
        {
            var myGrid = new Grid();
            myGrid.MoveMode();
            
            while (true)
            {
                myGrid.Display();
                
                // Get move direction
                Console.WriteLine(" / / / Move with WASD \\ \\ \\");
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
                        continue;
                }

                myGrid.Move(dirString);
            }
        }
    }
}

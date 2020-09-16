using System;

namespace grid
{
    class MainMenu
    {
        static void Main(string[] args)
        {
            var myGrid = new Grid();
            
            Console.Clear();
            Console.WriteLine("          / / /  G R I D  \\ \\ \\");
            Console.WriteLine("Catch the + signs before the timer runs out!");
            Console.WriteLine("             Move with WASD");
            Console.WriteLine("\n        PRESS ANY BUTTON TO PLAY!");
            var input = Console.ReadKey().Key;
            myGrid.Play();
        }
    }
}

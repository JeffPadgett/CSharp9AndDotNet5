using System;

namespace GameConsole
{
    class Program
    {
        static void Main()
        {
            var player = new PlayerCharacter();
            player.Name = "Brittany";

            PlayerDisplayer.Write(player);

            Console.ReadLine();
        }
    }
}

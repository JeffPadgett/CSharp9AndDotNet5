using System;

namespace GameConsole
{
    class Program
    {
        static void Main()
        {
            PlayerCharacter player = new PlayerCharacter();
            player.DaysSinceLastLogin = 42;

            //int days = player.DaysSinceLastLogin.Value;
            int days = player?.DaysSinceLastLogin ?? -1;



            Console.WriteLine(days);

            Console.ReadLine();
        }
    }
}

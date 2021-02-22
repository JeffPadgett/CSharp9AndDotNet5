using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1986, 6, 25);
            bob.FavoriteAncientWonder = WondersOfThEAncientWorld.StatueOfZeusAtOlympia;
            bob.BucketList = WondersOfThEAncientWorld.HangingGardensOfBabylon | WondersOfThEAncientWorld.MausoleumAtHalicarnassus | WondersOfThEAncientWorld.TempleOfArtemisAtEphesus | WondersOfThEAncientWorld.ColossusOfRhodes;

            WriteLine($"{bob.Name} was born on {bob.DateOfBirth:dddd, d MMMM yyyy}, and his favorite wonder is {bob.FavoriteAncientWonder}, also it is an enum and the number is {(int)bob.FavoriteAncientWonder}");
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");
        }
    }
}

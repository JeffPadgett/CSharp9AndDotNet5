using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
            new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
            new Command { Id = 0, HowTo = "Be cool", Line = "Comb your hair", Platform = "Don't know" },
            new Command { Id = 0, HowTo = "Be a good dad", Line = "Spend time", Platform = "Take to disney" },
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
        }
    }
}

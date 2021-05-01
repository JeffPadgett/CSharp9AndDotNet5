using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {

        List<Command> commands = new List<Command>
            {
            new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" },
            new Command { Id = 0, HowTo = "Be cool", Line = "Comb your hair", Platform = "Don't know" },
            new Command { Id = 0, HowTo = "Be a good dad", Line = "Spend time", Platform = "Take to disney" },
            };

        public void CreateCommand(Command cmd)
        {
            commands.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return commands.Where(c => c.Id == id).Single();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }
    }
}

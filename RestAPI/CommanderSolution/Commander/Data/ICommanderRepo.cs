using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Data
{
    interface ICommanderRepo
    {
        public IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}

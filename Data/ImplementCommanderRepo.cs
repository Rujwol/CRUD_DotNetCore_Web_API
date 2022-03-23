using Royal_application_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Royal_application_api.Data
{
    public class ImplementCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{ Id = 0, HowTo="Boil an egg", Line ="Boil Water", Platform="In frying pan"},
                new Command{ Id = 1, HowTo="Use a towel", Line ="Clean your face", Platform="In the toielt"},
                new Command{ Id = 2, HowTo="Exercise", Line ="Stay Fit", Platform="In the gym"},
                new Command{ Id = 3, HowTo="Fry Chicken", Line ="Bring sauce", Platform="In frying pan"},
                new Command{ Id = 4, HowTo="Serve the food", Line ="Eat the food", Platform="In the plates"},
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "Boil an egg", Line ="Boil Water", Platform = "In frying pan" };
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

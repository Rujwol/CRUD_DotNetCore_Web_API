using Royal_application_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Royal_application_api.Data
{
    // while making Interface always think in theoritical perspective ; as of what this contract provide
    public interface ICommanderRepo
    {
        bool SaveChanges();

        //GET data
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);

        //Create data : POST
        void CreateCommand(Command cmd);

        //Update the record
        void UpdateCommand(Command cmd);
        //Delete records
        void DeleteCommand(Command cmd);

    }
}

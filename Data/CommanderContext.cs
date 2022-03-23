using Microsoft.EntityFrameworkCore;
using Royal_application_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Royal_application_api.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext>opt) : base(opt)
        {
    
        }
        public DbSet<Command> Commands { get; set; }// represents a table
    }
}

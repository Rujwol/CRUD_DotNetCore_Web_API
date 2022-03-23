using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Royal_application_api.Dtos
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        //Dont need platform to give to cliet so commentong it out
        //public string Platform { get; set; }

    }
}

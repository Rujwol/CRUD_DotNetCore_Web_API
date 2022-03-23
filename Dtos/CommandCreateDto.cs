using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Royal_application_api.Dtos
{
    public class CommandCreateDto
    {
        //Resson to put data annotation here is to throw 400 error (bad request) rather than 500 intrernal server error

        // We will not be suppling primery key to DB as it Db makes it itself
        //public int Id { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}

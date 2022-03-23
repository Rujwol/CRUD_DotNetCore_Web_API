using AutoMapper;
using Royal_application_api.Dtos;
using Royal_application_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Royal_application_api.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            //Source <-> Target

            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandCreateDto, Command>();

            CreateMap<CommandUpdateDto, Command>();

            //for PATCH
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}

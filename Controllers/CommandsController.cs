using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Royal_application_api.Data;
using Royal_application_api.Dtos;
using Royal_application_api.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace Royal_application_api.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase //@controllerBase@ is with no view supprt but @Controller@ is with view support
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }


        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            //string result =JsonSerializer.Serialize(commandItems);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        //Reason to put Name in attribute is to use it inside controller by other functions
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id); // this returns data of class "Command"
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem)); //but while returning the data we are mapping it to CommandReadDto which is the return type of this funciton
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandCreateDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commanModal = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commanModal);
            _repository.SaveChanges();
            var commandReadDto = _mapper.Map<CommandReadDto>(commanModal);


            //"CreatedAtRoute" used for 201 response
            return CreatedAtRoute(nameof(GetCommandById), new { Id = commandReadDto.Id }, commandReadDto);
            //return Ok(commandReadDto);
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo); //This updates

            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            //TYPE OF DATA TO BE SENT FROM FRONT END OR API IS
            //[{"op": "replace","path": "/howto","value": "test2 in how to"}]
            
            
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commadToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commadToPatch, ModelState);
            if (!TryValidateModel(commadToPatch))
            {
                return ValidationProblem(ModelState); //This Validates
            }

            _mapper.Map(commadToPatch, commandModelFromRepo); //This updates

            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepo _repo;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repo, IMapper mapper)
    {
      _repo = repo ?? throw new ArgumentNullException(paramName: nameof(repo));
      _mapper = mapper ?? throw new ArgumentNullException(paramName: nameof(mapper));
    }

    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
      IEnumerable<Command> commandItems = _repo.GetAllCommands();
      IEnumerable<CommandReadDto> dtos = _mapper.Map<IEnumerable<CommandReadDto>>(commandItems);

      return Ok(dtos);
    }

    [HttpGet("{id}")]
    public ActionResult<CommandReadDto> GetCommandById(int id)
    {
      Command command = _repo.GetCommandById(id);

      if (command != null)
      {
        CommandReadDto dto = _mapper.Map<CommandReadDto>(command);
        return Ok(dto);
      }

      return NotFound();
    }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepo _repo;

    public CommandsController(ICommanderRepo repo)
    {

      _repo = repo ?? throw new ArgumentNullException(paramName: nameof(repo));
    }

    [HttpGet]
    public ActionResult<IEnumerable<Command>> GetAllCommands()
    {
      var commandItems = _repo.GetAllCommands();

      return Ok(commandItems);
    }

    [HttpGet("{id}")]
    public ActionResult<Command> GetCommandById(int id)
    {
      var command = _repo.GetCommandById(id);

      return Ok(command);
    }
  }
}

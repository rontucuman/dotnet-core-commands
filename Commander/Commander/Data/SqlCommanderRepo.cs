using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
  public class SqlCommanderRepo : ICommanderRepo
  {
    private readonly CommanderContext _context;

    public SqlCommanderRepo(CommanderContext context)
    {
      _context = context ?? throw new ArgumentNullException(paramName: nameof(context));
    }

    public IEnumerable<Command> GetAllCommands()
    {
      return _context.Commands.ToList();
    }

    public Command GetCommandById(int id)
    {
      return _context.Commands.Find(id);
    }
  }
}
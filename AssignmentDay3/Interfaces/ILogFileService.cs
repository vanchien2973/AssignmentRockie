using AssignmentDay3.Middlewares;
using AssignmentDay3.Models;

namespace AssignmentDay3.Interfaces;

public interface ILogFileService
{
    Task LogRequestAsync(LogData logData);
}

using System.Text;
using AssignmentDay3.Interfaces;
using AssignmentDay3.Middlewares;
using AssignmentDay3.Models;

namespace AssignmentDay3.Services;

public class LogFileService : ILogFileService
{
    private readonly string _logDirectory;
    private readonly ILogger<LogFileService> _logger;

    public LogFileService(ILogger<LogFileService> logger)
    {
        _logger = logger;
        _logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "LogFiles");
        
        try
        {
            Directory.CreateDirectory(_logDirectory);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Failed to create log directory");
            throw;
        }
    }

    public async Task LogRequestAsync(LogData logData)
    {
        if (logData == null)
        {
            _logger.LogWarning("Attempted to log null log data");
            return;
        }

        var logFilePath = GetLogFilePath();
    
        try
        {
            if (!CanWriteToFile(logFilePath))
            {
                _logger.LogError("Cannot write to log file {FilePath}", logFilePath);
                return;
            }

            await File.AppendAllTextAsync(logFilePath, logData.ToString(), Encoding.UTF8);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to write to log file {FilePath}", logFilePath);
        }
    }

    private bool CanWriteToFile(string filePath)
    {
        try
        {
            using var stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
            return true;
        }
        catch (UnauthorizedAccessException)
        {
            return false;
        }
        catch (IOException)
        {
            return false;
        }
    }

    private string GetLogFilePath() => 
        Path.Combine(_logDirectory, $"request_log_{DateTime.Now:yyyyMMdd}.txt");
}


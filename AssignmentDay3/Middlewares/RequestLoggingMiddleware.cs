using System.Text;
using AssignmentDay3.Interfaces;
using AssignmentDay3.Models;

namespace AssignmentDay3.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogFileService _logFileService;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogFileService logFileService, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logFileService = logFileService;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();
    
        string requestBody = string.Empty;
        try
        {
            using (var reader = new StreamReader(
                       context.Request.Body, 
                       Encoding.UTF8, 
                       detectEncodingFromByteOrderMarks: false,
                       bufferSize: 1024, 
                       leaveOpen: true))
            {
                requestBody = await reader.ReadToEndAsync();
                context.Request.Body.Position = 0;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to read request body");
            requestBody = "[Error reading body]";
        }

        var logData = new LogData
        {
            Schema = context.Request.Scheme,
            Host = context.Request.Host.ToString(),
            Path = context.Request.Path.ToString(),
            QueryString = context.Request.QueryString.ToString(),
            Body = requestBody
        };
    
        // Fire and forget the logging to not block the request pipeline
        _ = Task.Run(() => _logFileService.LogRequestAsync(logData))
            .ContinueWith(t => 
            {
                if (t.IsFaulted)
                    _logger.LogError(t.Exception, "Failed to log request");
            });
    
        await _next(context);
    }
}
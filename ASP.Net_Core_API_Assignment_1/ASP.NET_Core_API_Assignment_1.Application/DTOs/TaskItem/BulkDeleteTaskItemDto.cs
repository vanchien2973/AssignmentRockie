namespace ASP.NET_Core_API_Assignment_1.Application.DTOs;

public class BulkDeleteTaskItemDto
{
    public List<Guid> TaskIds { get; set; }
}
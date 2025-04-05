using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_API_Assignment_1.Application.DTOs;

public class BulkDeleteTaskItemDto
{
    [MinLength(1, ErrorMessage = "At least one task ID is required")]
    public List<Guid> TaskIds { get; set; }
}
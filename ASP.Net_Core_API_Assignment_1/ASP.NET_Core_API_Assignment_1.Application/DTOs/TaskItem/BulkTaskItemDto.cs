using System.ComponentModel.DataAnnotations;
using ASP.NET_Core_API_Assignment_1.Application.Validators;

namespace ASP.NET_Core_API_Assignment_1.Application.DTOs.TaskItem;

public class BulkTaskItemDto
{
    [MinLength(1, ErrorMessage = "At least one task is required")]
    [UniqueTitle(ErrorMessage = "Duplicate titles found in bulk request")]
    public List<CreateTaskItemDto> Tasks { get; set; }
}
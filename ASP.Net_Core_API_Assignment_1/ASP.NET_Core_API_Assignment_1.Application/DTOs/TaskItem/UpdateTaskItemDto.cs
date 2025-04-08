using System.ComponentModel.DataAnnotations;
using ASP.NET_Core_API_Assignment_1.Application.Validators;

namespace ASP.NET_Core_API_Assignment_1.Application.DTOs.TaskItem;

public class UpdateTaskItemDto
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(200, ErrorMessage = "Title must not exceed 200 characters")]
    [UniqueTitle(ErrorMessage = "Title already exists")]
    public string Title { get; set; }

    public bool IsCompleted { get; set; }
}
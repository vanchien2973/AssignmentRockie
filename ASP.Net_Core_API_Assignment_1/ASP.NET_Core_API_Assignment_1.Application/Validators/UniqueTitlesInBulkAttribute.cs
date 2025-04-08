using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ASP.NET_Core_API_Assignment_1.Application.DTOs;
using ASP.NET_Core_API_Assignment_1.Domain.Interfaces;

namespace ASP.NET_Core_API_Assignment_1.Application.Validators;

public class UniqueTitleAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null) return ValidationResult.Success;

        var title = value.ToString();
        var repository = (ITaskRepository)validationContext.GetService(typeof(ITaskRepository))!;
        
        var normalizedTitle = Regex.Replace(title, @"\s+", " ").Trim().ToLower();
        
        var exists = repository.TitleExistsAsync(normalizedTitle).GetAwaiter().GetResult();
            
        return exists 
            ? new ValidationResult("Title already exists") 
            : ValidationResult.Success;
    }
}
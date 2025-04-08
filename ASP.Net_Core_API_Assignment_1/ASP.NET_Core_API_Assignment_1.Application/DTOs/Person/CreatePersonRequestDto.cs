namespace ASP.NET_Core_API_Assignment_1.Application.DTOs.Person;

public class CreatePersonRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string BirthPlace { get; set; } = string.Empty;
}
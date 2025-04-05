using MVC_NET_Core_Assignment_1.Models;
using MVC_NET_Core_Assignment_1.Repositories;

namespace MVC_NET_Core_Assignment_1.Services;

public class PersonService(IPersonRepository repository) : IPersonService
{
    public IEnumerable<Person?> GetMaleMembers()
    {
        return repository.GetAllPeople()
            .Where(p => p.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase));
    }
    
    public Person? GetOldestMember()
    {
        return repository.GetAllPeople()
            .OrderBy(p => p.DateOfBirth)
            .FirstOrDefault();
    }
    
    public IEnumerable<string> GetFullNames()
    {
        return repository.GetAllPeople()
            .Select(p => $"{p.LastName} {p.FirstName}");
    }
    
    public IEnumerable<Person?> FilterByBirthYear(string action, int year)
    {
        if (string.IsNullOrWhiteSpace(action))
        {
            throw new ArgumentException("Action parameter is required. Valid values: equal, greater, less");
        }

        return action.ToLower() switch
        {
            "equal" => repository.GetAllPeople().Where(p => p.DateOfBirth.Year == year),
            "greater" => repository.GetAllPeople().Where(p => p.DateOfBirth.Year > year),
            "less" => repository.GetAllPeople().Where(p => p.DateOfBirth.Year < year),
            _ => throw new ArgumentException("Invalid action parameter. Valid values: equal, greater, less")
        };
    }
    
    public byte[] ExportToExcel()
    {
        const string headers = "First Name,Last Name,Gender,Date of Birth,Phone Number,Birth Place,Is Graduated";
        var csvRows = repository.GetAllPeople()
            .Select(p => $"\"{p.FirstName}\",\"{p.LastName}\",\"{p.Gender}\"," +
                        $"\"{p.DateOfBirth:yyyy-MM-dd}\",\"{p.PhoneNumber}\"," +
                        $"\"{p.BirthPlace}\",\"{(p.IsGraduated ? "Yes" : "No")}\"");

        var csvContent = $"{headers}\n{string.Join("\n", csvRows)}";
        return System.Text.Encoding.UTF8.GetBytes(csvContent);
    }
}
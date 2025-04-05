using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Services;

public interface IPersonService
{
    IEnumerable<Person?> GetMaleMembers();
    Person? GetOldestMember();
    IEnumerable<string> GetFullNames();
    IEnumerable<Person?> FilterByBirthYear(string action, int year);
    byte[] ExportToExcel();
}
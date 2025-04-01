using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Services;

public interface IRookiesService
{
    IEnumerable<Person?> GetMaleMembers();
    Person? GetOldestMember();
    IEnumerable<string> GetFullNames();
    IEnumerable<Person?> FilterByBirthYear(string action, int year);
    byte[] ExportToExcel();
}
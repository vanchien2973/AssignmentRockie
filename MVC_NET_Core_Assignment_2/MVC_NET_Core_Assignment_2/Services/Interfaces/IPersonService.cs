using MVC_NET_Core_Assignment_1.DTOs.Person;
using MVC_NET_Core_Assignment_1.Helpers;

namespace MVC_NET_Core_Assignment_1.Services.Interfaces;

public interface IPersonService
{
    PaginatedList<PersonDto> GetPaginatedPeople(int pageIndex, int pageSize);
    PaginatedList<PersonDto> GetPaginatedMaleMembers(int pageIndex, int pageSize);
    PersonDto? GetOldestMember();
    IEnumerable<PersonFullNameDto> GetFullNames();
    IEnumerable<PersonDto> FilterByBirthYear(string condition, int year);
    byte[] ExportToExcel();
    PersonDto? GetById(int id);
    PersonDto Create(PersonCreateDto person);
    PersonDto? Update(int id, PersonUpdateDto person);
    bool Delete(int id);
    PersonUpdateDto? GetForUpdate(int id);
}
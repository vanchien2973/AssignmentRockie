using System.Text;
using ClosedXML.Excel;
using MVC_NET_Core_Assignment_1.DTOs;
using MVC_NET_Core_Assignment_1.Helpers;
using MVC_NET_Core_Assignment_1.Models;
using MVC_NET_Core_Assignment_1.Repositories.Interfaces;
using MVC_NET_Core_Assignment_1.Services.Interfaces;

namespace MVC_NET_Core_Assignment_1.Services;

public class PersonService(IPersonRepository repository) : IPersonService
{
    // public IEnumerable<PersonDto> GetAll() => repository.GetAll().Select(p => MapToDto(p));
    public PaginatedList<PersonDto> GetPaginatedPeople(int pageIndex, int pageSize)
    {
        var people = repository.GetAll().Select(p => MapToDto(p));
        return PaginatedList<PersonDto>.Create(people, pageIndex, pageSize);
    }
    
    public PaginatedList<PersonDto> GetPaginatedMaleMembers(int pageIndex, int pageSize)
    {
        var males = repository.GetAll()
            .Where(p => p.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
            .Select(p => MapToDto(p));
        return PaginatedList<PersonDto>.Create(males, pageIndex, pageSize);
    }

    // public IEnumerable<PersonDto> GetMaleMembers()
    // {
    //     return repository.GetAll()
    //         .Where(p => p.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
    //         .Select(p => MapToDto(p));
    // }

    public PersonDto? GetOldestMember()
    {
        var oldest = repository.GetAll().MinBy(p => p.DateOfBirth);
        return oldest != null ? MapToDto(oldest) : null;
    }

    public IEnumerable<PersonFullNameDto> GetFullNames()
    {
        return repository.GetAll()
            .Select(p => new PersonFullNameDto { FullName = p.FullName });
    }

    public IEnumerable<PersonDto> FilterByBirthYear(string condition, int year)
    {
        if (string.IsNullOrEmpty(condition))
        {
            throw new ArgumentException("Condition parameter is required");
        }

        var filtered = condition.ToLower() switch
        {
            "equal" => repository.GetAll().Where(p => p.DateOfBirth.Year == year),
            "greater" => repository.GetAll().Where(p => p.DateOfBirth.Year > year),
            "less" => repository.GetAll().Where(p => p.DateOfBirth.Year < year),
            _ => throw new ArgumentException("Invalid condition parameter")
        };
        return filtered.Select(p => MapToDto(p));
    }

    public byte[] ExportToExcel()
    {
        var people = repository.GetAll();

        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("People");
            var headerRow = worksheet.FirstRow();
            headerRow.Cell(1).Value = "FirstName";
            headerRow.Cell(2).Value = "LastName";
            headerRow.Cell(3).Value = "Gender";
            headerRow.Cell(4).Value = "DateOfBirth";
            headerRow.Cell(5).Value = "PhoneNumber";
            headerRow.Cell(6).Value = "BirthPlace";
            headerRow.Cell(7).Value = "IsGraduated";
            headerRow.Style.Font.Bold = true;
            headerRow.Style.Fill.BackgroundColor = XLColor.LightGray;

            var row = 2;
            foreach (var person in people)
            {
                worksheet.Cell(row, 1).Value = person.FirstName;
                worksheet.Cell(row, 2).Value = person.LastName;
                worksheet.Cell(row, 3).Value = person.Gender;
                worksheet.Cell(row, 4).Value = person.DateOfBirth;
                worksheet.Cell(row, 4).Style.DateFormat.Format = "yyyy-MM-dd";
                worksheet.Cell(row, 5).Value = person.PhoneNumber;
                worksheet.Cell(row, 6).Value = person.BirthPlace;
                worksheet.Cell(row, 7).Value = person.IsGraduated ? "Yes" : "No";
                row++;
            }

            worksheet.Columns().AdjustToContents();
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }

    public PersonDto? GetById(int id) => repository.GetById(id) is Person p ? MapToDto(p) : null;

    public PersonDto Create(PersonCreateDto personDto)
    {
        var person = new Person
        {
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Gender = personDto.Gender,
            DateOfBirth = personDto.DateOfBirth,
            PhoneNumber = personDto.PhoneNumber,
            BirthPlace = personDto.BirthPlace,
            IsGraduated = personDto.IsGraduated
        };
        return MapToDto(repository.Create(person));
    }

    public PersonDto? Update(int id, PersonUpdateDto personDto)
    {
        var person = new Person
        {
            Id = id,
            FirstName = personDto.FirstName,
            LastName = personDto.LastName,
            Gender = personDto.Gender,
            DateOfBirth = personDto.DateOfBirth,
            PhoneNumber = personDto.PhoneNumber,
            BirthPlace = personDto.BirthPlace,
            IsGraduated = personDto.IsGraduated
        };
        var updated = repository.Update(id, person);
        return updated != null ? MapToDto(updated) : null;
    }

    public bool Delete(int id) => repository.Delete(id);

    private static PersonDto MapToDto(Person person) => new()
    {
        Id = person.Id,
        FirstName = person.FirstName,
        LastName = person.LastName,
        Gender = person.Gender,
        DateOfBirth = person.DateOfBirth,
        PhoneNumber = person.PhoneNumber,
        BirthPlace = person.BirthPlace,
        IsGraduated = person.IsGraduated
    };
}
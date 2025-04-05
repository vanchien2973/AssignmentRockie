using MVC_NET_Core_Assignment_1.Data;
using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly List<Person?> _people;
    private int _nextId;

    public PersonRepository(IDummyData dummyData)
    {
        _people = dummyData.GetDummyData().ToList();
        _nextId = _people.Count > 0 ? _people.Max(p => p.Id) + 1 : 1;
    }

    public IEnumerable<Person> GetAllPeople()
    {
        return _people;
    }

    public Person? GetPersonById(int id)
    {
        return _people.FirstOrDefault(p => p.Id == id);
    }

    public void AddPerson(Person person)
    {
        person.Id = _nextId++;
        _people.Add(person);
    }

    public void UpdatePerson(Person person)
    {
        var existingPerson = GetPersonById(person.Id);
        if (existingPerson != null)
        {
            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Gender = person.Gender;
            existingPerson.DateOfBirth = person.DateOfBirth;
            existingPerson.PhoneNumber = person.PhoneNumber;
            existingPerson.BirthPlace = person.BirthPlace;
            existingPerson.IsGraduated = person.IsGraduated;
        }
    }

    public void DeletePerson(int id)
    {
        var person = GetPersonById(id);
        if (person != null)
        {
            _people.Remove(person);
        }
    }
}
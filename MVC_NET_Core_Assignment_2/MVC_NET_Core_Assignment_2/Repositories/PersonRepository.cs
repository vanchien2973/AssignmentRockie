using MVC_NET_Core_Assignment_1.Data;
using MVC_NET_Core_Assignment_1.Models;
using MVC_NET_Core_Assignment_1.Repositories.Interfaces;

namespace MVC_NET_Core_Assignment_1.Repositories;

public class PersonRepository : IPersonRepository
{
    private static readonly List<Person> _people = [];
    private static int _nextId = 1;

    public PersonRepository(IDummyData dummyData)
    {
        if (_people.Count != 0) return;
        _people.AddRange(dummyData.GetDummyData());
        _nextId = _people.Count + 1;
    }

    public IEnumerable<Person> GetAll() => _people;

    public Person? GetById(int id) => _people.FirstOrDefault(p => p.Id == id);

    public Person Create(Person person)
    {
        person.Id = _nextId++;
        person.CreatedAt = DateTime.Now;
        person.UpdatedAt = DateTime.Now;
        _people.Add(person);
        return person;
    }

    public Person? Update(int id, Person person)
    {
        var existingPerson = _people.FirstOrDefault(p => p.Id == id);
        if (existingPerson == null) return null;

        existingPerson.FirstName = person.FirstName;
        existingPerson.LastName = person.LastName;
        existingPerson.Gender = person.Gender;
        existingPerson.DateOfBirth = person.DateOfBirth;
        existingPerson.PhoneNumber = person.PhoneNumber;
        existingPerson.BirthPlace = person.BirthPlace;
        existingPerson.IsGraduated = person.IsGraduated;
        existingPerson.UpdatedAt = DateTime.Now;
        return existingPerson;
    }

    public bool Delete(int id)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        if (person == null) return false;

        _people.Remove(person);
        return true;
    }
}
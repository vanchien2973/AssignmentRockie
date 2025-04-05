using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Repositories;

public interface IPersonRepository
{
    IEnumerable<Person> GetAllPeople();
    Person? GetPersonById(int id);
    void AddPerson(Person person);
    void UpdatePerson(Person person);
    void DeletePerson(int id);
}
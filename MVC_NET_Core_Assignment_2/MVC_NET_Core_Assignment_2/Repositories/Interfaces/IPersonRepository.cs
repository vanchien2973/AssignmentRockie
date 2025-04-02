using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Repositories.Interfaces;

public interface IPersonRepository
{
    IEnumerable<Person> GetAll();
    Person? GetById(int id);
    Person Create(Person person);
    Person? Update(int id, Person person);
    bool Delete(int id);
}
using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Repositories;

public interface IRookiesRepository
{
    IEnumerable<Person?> GetAllPeople();
}
using MVC_NET_Core_Assignment_1.Data;
using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Repositories;

public class RookiesRepository(IDummyData dummyData) : IRookiesRepository
{
    public IEnumerable<Person?> GetAllPeople()
    {
        return dummyData.GetDummyData();
    }
}
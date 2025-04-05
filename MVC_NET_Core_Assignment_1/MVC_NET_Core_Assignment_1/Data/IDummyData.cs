using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Data;

public interface IDummyData
{
    IEnumerable<Person?> GetDummyData();
}
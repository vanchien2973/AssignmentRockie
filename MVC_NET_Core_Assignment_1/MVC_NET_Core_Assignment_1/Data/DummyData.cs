using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Data;

public class DummyData : IDummyData
{
    public IEnumerable<Person?> GetDummyData()
    {
        return
        [
            new Person
            {
                Id = 1,
                FirstName = "Phuong",
                LastName = "Nguyen Nam",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 22),
                PhoneNumber = "0987678888",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },

            new Person
            {
                Id = 2,
                FirstName = "Nam",
                LastName = "Nguyen Thanh",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 20),
                PhoneNumber = "0987678686",
                BirthPlace = "Bac Ninh",
                IsGraduated = false
            },

            new Person
            {
                Id = 3,
                FirstName = "Son",
                LastName = "Do Hong",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 6),
                PhoneNumber = "0987654321",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },

            new Person
            {
                Id = 4,
                FirstName = "Huy",
                LastName = "Nguyen Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(1996, 1, 26),
                PhoneNumber = "0987647383",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },

            new Person
            {
                Id = 5,
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 2, 5),
                PhoneNumber = "0987676543",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            },

            new Person
            {
                Id = 6,
                FirstName = "Long",
                LastName = "Lai Quoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 5, 30),
                PhoneNumber = "0987777732",
                BirthPlace = "Bac Ninh",
                IsGraduated = true
            },

            new Person
            {
                Id = 7,
                FirstName = "Thanh",
                LastName = "Tran Chi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 9, 18),
                PhoneNumber = "0987876543",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            }
        ];
    }
}
using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_1.Data
{
    public class DummyData : IDummyData
    {
        public List<Person> GetDummyData()
        {
            return new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "Phuong",
                    LastName = "Nguyen Nam",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2001, 1, 22),
                    PhoneNumber = "0987678888",
                    BirthPlace = "Hanoi",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-100),
                    UpdatedAt = DateTime.Now.AddDays(-50)
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Mai",
                    LastName = "Le Thi",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2000, 5, 15),
                    PhoneNumber = "0987654321",
                    BirthPlace = "Hai Phong",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-95),
                    UpdatedAt = DateTime.Now.AddDays(-45)
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Son",
                    LastName = "Do Hong",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000, 11, 6),
                    PhoneNumber = "0987654321",
                    BirthPlace = "Hanoi",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-90),
                    UpdatedAt = DateTime.Now.AddDays(-40)
                },
                new Person
                {
                    Id = 4,
                    FirstName = "Lan",
                    LastName = "Nguyen Thi",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1998, 8, 20),
                    PhoneNumber = "0987123456",
                    BirthPlace = "Da Nang",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-85),
                    UpdatedAt = DateTime.Now.AddDays(-35)
                },
                new Person
                {
                    Id = 5,
                    FirstName = "Hoang",
                    LastName = "Phuong Viet",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1999, 2, 5),
                    PhoneNumber = "0987676543",
                    BirthPlace = "Hanoi",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-80),
                    UpdatedAt = DateTime.Now.AddDays(-30)
                },
                new Person
                {
                    Id = 6,
                    FirstName = "Hue",
                    LastName = "Tran Thi",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2001, 3, 12),
                    PhoneNumber = "0987656789",
                    BirthPlace = "Hue",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-75),
                    UpdatedAt = DateTime.Now.AddDays(-25)
                },
                new Person
                {
                    Id = 7,
                    FirstName = "Thanh",
                    LastName = "Tran Chi",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000, 9, 18),
                    PhoneNumber = "0987876543",
                    BirthPlace = "Hanoi",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-70),
                    UpdatedAt = DateTime.Now.AddDays(-20)
                },
                new Person
                {
                    Id = 8,
                    FirstName = "Huong",
                    LastName = "Pham Thi",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1997, 7, 25),
                    PhoneNumber = "0987123123",
                    BirthPlace = "Nam Dinh",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-65),
                    UpdatedAt = DateTime.Now.AddDays(-15)
                },
                new Person
                {
                    Id = 9,
                    FirstName = "Dung",
                    LastName = "Vu Manh",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1996, 4, 30),
                    PhoneNumber = "0987999888",
                    BirthPlace = "Hai Duong",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-60),
                    UpdatedAt = DateTime.Now.AddDays(-10)
                },
                new Person
                {
                    Id = 10,
                    FirstName = "Linh",
                    LastName = "Nguyen Thuy",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2002, 12, 3),
                    PhoneNumber = "0987654999",
                    BirthPlace = "Hanoi",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-55),
                    UpdatedAt = DateTime.Now.AddDays(-5)
                },
                new Person
                {
                    Id = 11,
                    FirstName = "Binh",
                    LastName = "Le Minh",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1995, 6, 10),
                    PhoneNumber = "0987111222",
                    BirthPlace = "Ho Chi Minh City",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-99),
                    UpdatedAt = DateTime.Now.AddDays(-49)
                },
                new Person
                {
                    Id = 12,
                    FirstName = "Nga",
                    LastName = "Tran Hong",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1999, 10, 8),
                    PhoneNumber = "0987999111",
                    BirthPlace = "Hai Phong",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-94),
                    UpdatedAt = DateTime.Now.AddDays(-44)
                },
                new Person
                {
                    Id = 13,
                    FirstName = "Khanh",
                    LastName = "Do Quoc",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1998, 1, 29),
                    PhoneNumber = "0987222333",
                    BirthPlace = "Da Nang",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-89),
                    UpdatedAt = DateTime.Now.AddDays(-39)
                },
                new Person
                {
                    Id = 14,
                    FirstName = "Tuan",
                    LastName = "Pham Duy",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1997, 3, 21),
                    PhoneNumber = "0987555666",
                    BirthPlace = "Can Tho",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-84),
                    UpdatedAt = DateTime.Now.AddDays(-34)
                },
                new Person
                {
                    Id = 15,
                    FirstName = "Anh",
                    LastName = "Nguyen Bao",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2000, 7, 14),
                    PhoneNumber = "0987666555",
                    BirthPlace = "Hue",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-79),
                    UpdatedAt = DateTime.Now.AddDays(-29)
                },
                new Person
                {
                    Id = 16,
                    FirstName = "Hieu",
                    LastName = "Tran Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1996, 12, 19),
                    PhoneNumber = "0987888999",
                    BirthPlace = "Hanoi",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-74),
                    UpdatedAt = DateTime.Now.AddDays(-24)
                },
                new Person
                {
                    Id = 17,
                    FirstName = "Thu",
                    LastName = "Le Thi",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2001, 9, 5),
                    PhoneNumber = "0987000111",
                    BirthPlace = "Ho Chi Minh City",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-69),
                    UpdatedAt = DateTime.Now.AddDays(-19)
                },
                new Person
                {
                    Id = 18,
                    FirstName = "Minh",
                    LastName = "Dang Khoa",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1999, 5, 28),
                    PhoneNumber = "0987333444",
                    BirthPlace = "Da Nang",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-64),
                    UpdatedAt = DateTime.Now.AddDays(-14)
                },
                new Person
                {
                    Id = 19,
                    FirstName = "Ly",
                    LastName = "Vu Thi",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2002, 2, 11),
                    PhoneNumber = "0987666777",
                    BirthPlace = "Can Tho",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-59),
                    UpdatedAt = DateTime.Now.AddDays(-9)
                },
                new Person
                {
                    Id = 20,
                    FirstName = "Phat",
                    LastName = "Nguyen Van",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1995, 11, 17),
                    PhoneNumber = "0987222666",
                    BirthPlace = "Hai Phong",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-54),
                    UpdatedAt = DateTime.Now.AddDays(-4)
                },
                new Person
                {
                    Id = 21,
                    FirstName = "Dung",
                    LastName = "Tran Thanh",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1997, 8, 26),
                    PhoneNumber = "0987333222",
                    BirthPlace = "Ho Chi Minh City",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-98),
                    UpdatedAt = DateTime.Now.AddDays(-48)
                },
                new Person
                {
                    Id = 22,
                    FirstName = "Chi",
                    LastName = "Nguyen Minh",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2000, 6, 30),
                    PhoneNumber = "0987444555",
                    BirthPlace = "Hanoi",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-93),
                    UpdatedAt = DateTime.Now.AddDays(-43)
                },
                new Person
                {
                    Id = 23,
                    FirstName = "Son",
                    LastName = "Do Manh",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1996, 4, 3),
                    PhoneNumber = "0987555777",
                    BirthPlace = "Hai Duong",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-88),
                    UpdatedAt = DateTime.Now.AddDays(-38)
                },
                new Person
                {
                    Id = 24,
                    FirstName = "Linh",
                    LastName = "Pham Anh",
                    Gender = "Female",
                    DateOfBirth = new DateTime(2001, 10, 20),
                    PhoneNumber = "0987999000",
                    BirthPlace = "Hue",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-83),
                    UpdatedAt = DateTime.Now.AddDays(-33)
                },
                new Person
                {
                    Id = 25,
                    FirstName = "Hoang",
                    LastName = "Le Tuan",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1998, 12, 9),
                    PhoneNumber = "0987222777",
                    BirthPlace = "Da Nang",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-78),
                    UpdatedAt = DateTime.Now.AddDays(-28)
                }
            };
        }
    }
}

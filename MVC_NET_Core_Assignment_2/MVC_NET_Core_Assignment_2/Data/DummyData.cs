using MVC_NET_Core_Assignment_1.Models;
using System;
using System.Collections.Generic;

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
                    IsGraduated = false
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
                    IsGraduated = true
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
                    IsGraduated = false
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
                    BirthPlace = "Hanoi",
                    IsGraduated = true
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
                    IsGraduated = false
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
                    IsGraduated = false
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
                    IsGraduated = true
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
                    IsGraduated = true
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
                    IsGraduated = false
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
                    IsGraduated = true
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
                    IsGraduated = true
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
                    IsGraduated = false
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
                    IsGraduated = true
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
                    IsGraduated = false
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
                    IsGraduated = true
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
                    IsGraduated = false
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
                    IsGraduated = true
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
                    IsGraduated = false
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
                    IsGraduated = true
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
                    IsGraduated = false
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
                    IsGraduated = true
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
                    IsGraduated = true
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
                    IsGraduated = false
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
                    IsGraduated = true
                }
            };
        }
    }
}

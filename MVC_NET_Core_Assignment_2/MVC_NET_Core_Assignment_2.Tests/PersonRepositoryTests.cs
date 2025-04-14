using Moq;
using MVC_NET_Core_Assignment_1.Data;
using MVC_NET_Core_Assignment_1.Models;
using MVC_NET_Core_Assignment_1.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC_NET_Core_Assignment_2.Tests
{
    [TestFixture]
    public class PersonRepositoryTests
    {
        private Mock<IDummyData> _mockDummyData;
        private PersonRepository _repository;
        private List<Person> _testData;

        [SetUp]
        public void Setup()
        {
            _testData = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    PhoneNumber = "1234567890",
                    BirthPlace = "Ha Noi",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now.AddDays(-5)
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1995, 5, 15),
                    PhoneNumber = "0987654321",
                    BirthPlace = "Ho Chi Minh",
                    IsGraduated = false,
                    CreatedAt = DateTime.Now.AddDays(-8),
                    UpdatedAt = DateTime.Now.AddDays(-3)
                }
            };

            _mockDummyData = new Mock<IDummyData>();
            _mockDummyData.Setup(m => m.GetDummyData()).Returns(_testData);
            _repository = new PersonRepository(_mockDummyData.Object);
        }

        [Test]
        public void GetAll_ReturnsList()
        {
            // Act
            var result = _repository.GetAll();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.First().Id, Is.EqualTo(1));
        }

        [Test]
        public void GetById_WithValidId_ReturnsPerson()
        {
            // Act
            var result = _repository.GetById(1);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
        }

        [Test]
        public void GetById_WithInvalidId_ReturnsNull()
        {
            // Act
            var result = _repository.GetById(99);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Create_ReturnsNewPerson()
        {
            // Arrange
            var newPerson = new Person
            {
                FirstName = "New",
                LastName = "Person",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 1, 1),
                PhoneNumber = "1112223333",
                BirthPlace = "Huế",
                IsGraduated = true
            };

            // Act
            var result = _repository.Create(newPerson);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(3));
            Assert.That(result.FirstName, Is.EqualTo("New"));
            Assert.That(result.LastName, Is.EqualTo("Person"));
            Assert.That(result.CreatedAt, Is.Not.EqualTo(default(DateTime)));
            Assert.That(result.UpdatedAt, Is.Not.EqualTo(default(DateTime)));
        }

        [Test]
        public void Update_WithValidId_UpdatesPersonAndReturnsUpdatedPerson()
        {
            // Arrange
            var id = 1;
            var personToUpdate = new Person
            {
                FirstName = "Updated",
                LastName = "Person",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                PhoneNumber = "9998887777",
                BirthPlace = "Cần Thơ",
                IsGraduated = false
            };

            // Act
            var result = _repository.Update(id, personToUpdate);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.FirstName, Is.EqualTo("Updated"));
            Assert.That(result.LastName, Is.EqualTo("Person"));
            Assert.That(result.PhoneNumber, Is.EqualTo("9998887777"));
            Assert.That(result.BirthPlace, Is.EqualTo("Cần Thơ"));
            Assert.That(result.IsGraduated, Is.EqualTo(false));
            Assert.That(result.UpdatedAt, Is.Not.EqualTo(_testData[0].UpdatedAt));
        }

        [Test]
        public void Update_WithInvalidId_ReturnsNull()
        {
            // Arrange
            var id = 99;
            var personToUpdate = new Person
            {
                FirstName = "Updated",
                LastName = "Person"
            };

            // Act
            var result = _repository.Update(id, personToUpdate);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Delete_WithValidId_ReturnsTrue()
        {
            // Act
            var result = _repository.Delete(1);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(_repository.GetAll().Count(), Is.EqualTo(1));
        }

        [Test]
        public void Delete_WithInvalidId_ReturnsFalse()
        {
            // Act
            var result = _repository.Delete(99);

            // Assert
            Assert.That(result, Is.False);
            Assert.That(_repository.GetAll().Count(), Is.EqualTo(2));
        }
    }
} 
using MVC_NET_Core_Assignment_1.DTOs.Person;
using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_2.UnitTests
{
    [TestFixture]
    public class ModelTests
    {
        [Test]
        public void Person_FullName_ReturnsCorrectFormat()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };

            // Act
            var fullName = person.FullName;

            // Assert
            Assert.That(fullName, Is.EqualTo("Doe John"));
        }

        [Test]
        public void Person_FullName_WithEmptyFirstName_ReturnsLastName()
        {
            // Arrange
            var person = new Person
            {
                FirstName = string.Empty,
                LastName = "Doe"
            };

            // Act
            var fullName = person.FullName;

            // Assert
            Assert.That(fullName, Is.EqualTo("Doe "));
        }

        [Test]
        public void Person_FullName_WithEmptyLastName_ReturnsFirstName()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = string.Empty
            };

            // Act
            var fullName = person.FullName;

            // Assert
            Assert.That(fullName, Is.EqualTo(" John"));
        }

        [Test]
        public void Person_FullName_WithBothNamesEmpty_ReturnsEmptyString()
        {
            // Arrange
            var person = new Person
            {
                FirstName = string.Empty,
                LastName = string.Empty
            };

            // Act
            var fullName = person.FullName;

            // Assert
            Assert.That(fullName, Is.EqualTo(" "));
        }

        [Test]
        public void PersonDto_FullName_ReturnsCorrectFormat()
        {
            // Arrange
            var dto = new PersonDto
            {
                FirstName = "John",
                LastName = "Doe"
            };

            // Act
            var fullName = dto.FullName;

            // Assert
            Assert.That(fullName, Is.EqualTo("Doe John"));
        }

        [Test]
        public void PersonDto_FullName_WithEmptyFirstName_ReturnsLastName()
        {
            // Arrange
            var dto = new PersonDto
            {
                FirstName = string.Empty,
                LastName = "Doe"
            };

            // Act
            var fullName = dto.FullName;

            // Assert
            Assert.That(fullName, Is.EqualTo("Doe "));
        }

        [Test]
        public void PersonDto_FullName_WithEmptyLastName_ReturnsFirstName()
        {
            // Arrange
            var dto = new PersonDto
            {
                FirstName = "John",
                LastName = string.Empty
            };

            // Act
            var fullName = dto.FullName;

            // Assert
            Assert.That(fullName, Is.EqualTo(" John"));
        }

        [Test]
        public void PersonDto_FullName_WithBothNamesEmpty_ReturnsEmptyString()
        {
            // Arrange
            var dto = new PersonDto
            {
                FirstName = string.Empty,
                LastName = string.Empty
            };

            // Act
            var fullName = dto.FullName;

            // Assert
            Assert.That(fullName, Is.EqualTo(" "));
        }

        [Test]
        public void PersonCreateDto_PropertiesCanBeSet()
        {
            // Arrange
            var dateOfBirth = new DateTime(1990, 1, 1);
            
            // Act
            var dto = new PersonCreateDto
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                DateOfBirth = dateOfBirth,
                PhoneNumber = "1234567890",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            };

            // Assert
            Assert.That(dto.FirstName, Is.EqualTo("John"));
            Assert.That(dto.LastName, Is.EqualTo("Doe"));
            Assert.That(dto.Gender, Is.EqualTo("Male"));
            Assert.That(dto.DateOfBirth, Is.EqualTo(dateOfBirth));
            Assert.That(dto.PhoneNumber, Is.EqualTo("1234567890"));
            Assert.That(dto.BirthPlace, Is.EqualTo("Ha Noi"));
            Assert.That(dto.IsGraduated, Is.True);
        }

        [Test]
        public void PersonUpdateDto_PropertiesCanBeSet()
        {
            // Arrange
            var dateOfBirth = new DateTime(1990, 1, 1);
            
            // Act
            var dto = new PersonUpdateDto
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                DateOfBirth = dateOfBirth,
                PhoneNumber = "1234567890",
                BirthPlace = "Ha Noi",
                IsGraduated = true
            };

            // Assert
            Assert.That(dto.Id, Is.EqualTo(1));
            Assert.That(dto.FirstName, Is.EqualTo("John"));
            Assert.That(dto.LastName, Is.EqualTo("Doe"));
            Assert.That(dto.Gender, Is.EqualTo("Male"));
            Assert.That(dto.DateOfBirth, Is.EqualTo(dateOfBirth));
            Assert.That(dto.PhoneNumber, Is.EqualTo("1234567890"));
            Assert.That(dto.BirthPlace, Is.EqualTo("Ha Noi"));
            Assert.That(dto.IsGraduated, Is.True);
        }

        [Test]
        public void PersonFullNameDto_PropertiesCanBeSet()
        {
            // Act
            var dto = new PersonFullNameDto
            {
                FullName = "Doe John"
            };

            // Assert
            Assert.That(dto.FullName, Is.EqualTo("Doe John"));
        }
    }
} 
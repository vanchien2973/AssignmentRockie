using Moq;
using MVC_NET_Core_Assignment_1.DTOs.Person;
using MVC_NET_Core_Assignment_1.Models;
using MVC_NET_Core_Assignment_1.Repositories.Interfaces;
using MVC_NET_Core_Assignment_1.Services;

namespace MVC_NET_Core_Assignment_2.UnitTests
{
    [TestFixture]
    public class PersonServiceTests
    {
        private Mock<IPersonRepository> _mockPersonRepository;
        private PersonService _personService;
        private List<Person> _testPeople;

        [SetUp]
        public void Setup()
        {
            _mockPersonRepository = new Mock<IPersonRepository>();
            _personService = new PersonService(_mockPersonRepository.Object);

            // Create Test Data
            _testPeople = new List<Person>
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
                },
                new Person
                {
                    Id = 3,
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1985, 3, 10),
                    PhoneNumber = "5551234567",
                    BirthPlace = "Da Nang",
                    IsGraduated = true,
                    CreatedAt = DateTime.Now.AddDays(-15),
                    UpdatedAt = DateTime.Now.AddDays(-2)
                }
            };
        }

        [Test]
        public void GetPaginatedPeople_ReturnsCorrectPageOfPeople()
        {
            // Arrange
            int pageIndex = 1;
            int pageSize = 2;
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);

            // Act
            var result = _personService.GetPaginatedPeople(pageIndex, pageSize);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[1].Id, Is.EqualTo(2));
            Assert.That(result.PageIndex, Is.EqualTo(pageIndex));
            Assert.That(result.PageSize, Is.EqualTo(pageSize));
            Assert.That(result.TotalCount, Is.EqualTo(3));
            Assert.That(result.TotalPages, Is.EqualTo(2));
        }

        [Test]
        public void GetPaginatedMaleMembers_ReturnsOnlyMales()
        {
            // Arrange
            int pageIndex = 1;
            int pageSize = 10;
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);

            // Act
            var result = _personService.GetPaginatedMaleMembers(pageIndex, pageSize);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(p => p.Gender == "Male"), Is.True);
            Assert.That(result.Any(p => p.Gender == "Female"), Is.False);
        }

        [Test]
        public void GetOldestMember_ReturnsPersonWithEarliestDateOfBirth()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);

            // Act
            var result = _personService.GetOldestMember();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(3));
            Assert.That(result.DateOfBirth, Is.EqualTo(new DateTime(1985, 3, 10)));
        }

        [Test]
        public void GetOldestMember_WithEmptyList_ReturnsNull()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(new List<Person>());

            // Act
            var result = _personService.GetOldestMember();

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void GetFullNames_ReturnsCorrectFullNamesList()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);

            // Act
            var result = _personService.GetFullNames().ToList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(3));
            Assert.That(result[0].FullName, Is.EqualTo("Doe John"));
            Assert.That(result[1].FullName, Is.EqualTo("Smith Jane"));
            Assert.That(result[2].FullName, Is.EqualTo("Johnson Bob"));
        }

        [Test]
        public void FilterByBirthYear_WithEqualCondition_ReturnsMatchingPeople()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);
            string condition = "equal";
            int year = 1990;

            // Act
            var result = _personService.FilterByBirthYear(condition, year).ToList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Id, Is.EqualTo(1));
            Assert.That(result[0].DateOfBirth.Year, Is.EqualTo(year));
        }

        [Test]
        public void FilterByBirthYear_WithGreaterCondition_ReturnsMatchingPeople()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);
            string condition = "greater";
            int year = 1990;

            // Act
            var result = _personService.FilterByBirthYear(condition, year).ToList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Id, Is.EqualTo(2));
            Assert.That(result[0].DateOfBirth.Year, Is.GreaterThan(year));
        }

        [Test]
        public void FilterByBirthYear_WithLessCondition_ReturnsMatchingPeople()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);
            string condition = "less";
            int year = 1990;

            // Act
            var result = _personService.FilterByBirthYear(condition, year).ToList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Id, Is.EqualTo(3));
            Assert.That(result[0].DateOfBirth.Year, Is.LessThan(year));
        }

        [Test]
        public void FilterByBirthYear_WithNullCondition_ThrowsArgumentException()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);
            string? condition = null;
            int year = 1990;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _personService.FilterByBirthYear(condition!, year));
            Assert.That(ex.Message, Is.EqualTo("Condition parameter is required"));
        }

        [Test]
        public void FilterByBirthYear_WithEmptyCondition_ThrowsArgumentException()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);
            string condition = "";
            int year = 1990;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _personService.FilterByBirthYear(condition, year));
            Assert.That(ex.Message, Is.EqualTo("Condition parameter is required"));
        }

        [Test]
        public void FilterByBirthYear_WithNoMatches_ReturnsEmptyList()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);
            string condition = "equal";
            int year = 2000; // No one has this birth year

            // Act
            var result = _personService.FilterByBirthYear(condition, year).ToList();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void FilterByBirthYear_WithMatchingAllConditions_ReturnsCorrectResults()
        {
            // Arrange
            var testData = new List<Person>
            {
                new Person { Id = 1, DateOfBirth = new DateTime(1990, 1, 1) },
                new Person { Id = 2, DateOfBirth = new DateTime(1995, 1, 1) },
                new Person { Id = 3, DateOfBirth = new DateTime(1990, 2, 1) },
                new Person { Id = 4, DateOfBirth = new DateTime(1985, 1, 1) }
            };
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(testData);
            
            // Act - Equal condition
            var equalResult = _personService.FilterByBirthYear("equal", 1990).ToList();
            
            // Act - Greater condition
            var greaterResult = _personService.FilterByBirthYear("greater", 1990).ToList();
            
            // Act - Less condition
            var lessResult = _personService.FilterByBirthYear("less", 1990).ToList();

            // Assert
            Assert.That(equalResult.Count, Is.EqualTo(2));
            Assert.That(equalResult.All(p => p.DateOfBirth.Year == 1990), Is.True);
            
            Assert.That(greaterResult.Count, Is.EqualTo(1));
            Assert.That(greaterResult[0].Id, Is.EqualTo(2));
            
            Assert.That(lessResult.Count, Is.EqualTo(1));
            Assert.That(lessResult[0].Id, Is.EqualTo(4));
        }

        [Test]
        public void ExportToExcel_ReturnsExcelByteArray()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);

            // Act
            var result = _personService.ExportToExcel();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.GreaterThan(0));
        }

        [Test]
        public void ExportToExcel_WithEmptyList_ReturnsEmptyByteArray()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(new List<Person>());

            // Act
            var result = _personService.ExportToExcel();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Length, Is.GreaterThan(0));
        }

        [Test]
        public void GetById_WithValidId_ReturnsPerson()
        {
            // Arrange
            int id = 1;
            _mockPersonRepository.Setup(r => r.GetById(id)).Returns(_testPeople.First());

            // Act
            var result = _personService.GetById(id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
        }

        [Test]
        public void GetById_WithInvalidId_ReturnsNull()
        {
            // Arrange
            int id = 99;
            _mockPersonRepository.Setup(r => r.GetById(id)).Returns((Person?)null);

            // Act
            var result = _personService.GetById(id);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Create_AddsNewPersonAndReturnsDto()
        {
            // Arrange
            var personCreateDto = new PersonCreateDto
            {
                FirstName = "New",
                LastName = "Person",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 1, 1),
                PhoneNumber = "1112223333",
                BirthPlace = "Huế",
                IsGraduated = true
            };

            var newPerson = new Person
            {
                Id = 4,
                FirstName = personCreateDto.FirstName,
                LastName = personCreateDto.LastName,
                Gender = personCreateDto.Gender,
                DateOfBirth = personCreateDto.DateOfBirth,
                PhoneNumber = personCreateDto.PhoneNumber,
                BirthPlace = personCreateDto.BirthPlace,
                IsGraduated = personCreateDto.IsGraduated,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _mockPersonRepository.Setup(r => r.Create(It.IsAny<Person>())).Returns(newPerson);

            // Act
            var result = _personService.Create(personCreateDto);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(4));
            Assert.That(result.FirstName, Is.EqualTo("New"));
            Assert.That(result.LastName, Is.EqualTo("Person"));
            
            _mockPersonRepository.Verify(r => r.Create(It.IsAny<Person>()), Times.Once);
        }

        [Test]
        public void GetForUpdate_WithValidId_ReturnsUpdateDto()
        {
            // Arrange
            int id = 1;
            _mockPersonRepository.Setup(r => r.GetById(id)).Returns(_testPeople.First());

            // Act
            var result = _personService.GetForUpdate(id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.FirstName, Is.EqualTo("John"));
            Assert.That(result.LastName, Is.EqualTo("Doe"));
            Assert.That(result.Gender, Is.EqualTo("Male"));
            Assert.That(result.DateOfBirth, Is.EqualTo(new DateTime(1990, 1, 1)));
            Assert.That(result.PhoneNumber, Is.EqualTo("1234567890"));
            Assert.That(result.BirthPlace, Is.EqualTo("Ha Noi"));
            Assert.That(result.IsGraduated, Is.EqualTo(true));
        }

        [Test]
        public void GetForUpdate_WithInvalidId_ReturnsNull()
        {
            // Arrange
            int id = 99;
            _mockPersonRepository.Setup(r => r.GetById(id)).Returns((Person?)null);

            // Act
            var result = _personService.GetForUpdate(id);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Update_WithValidData_UpdatesPersonAndReturnsDto()
        {
            // Arrange
            int id = 1;
            var personUpdateDto = new PersonUpdateDto
            {
                Id = id,
                FirstName = "Updated",
                LastName = "Person",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                PhoneNumber = "9998887777",
                BirthPlace = "Cần Thơ",
                IsGraduated = false
            };

            var existingPerson = _testPeople.First();
            var updatedPerson = new Person
            {
                Id = id,
                FirstName = personUpdateDto.FirstName,
                LastName = personUpdateDto.LastName,
                Gender = personUpdateDto.Gender,
                DateOfBirth = personUpdateDto.DateOfBirth,
                PhoneNumber = personUpdateDto.PhoneNumber,
                BirthPlace = personUpdateDto.BirthPlace,
                IsGraduated = personUpdateDto.IsGraduated,
                CreatedAt = existingPerson.CreatedAt,
                UpdatedAt = DateTime.Now
            };

            _mockPersonRepository.Setup(r => r.GetById(id)).Returns(existingPerson);
            _mockPersonRepository.Setup(r => r.Update(id, It.IsAny<Person>())).Returns(updatedPerson);

            // Act
            var result = _personService.Update(id, personUpdateDto);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.FirstName, Is.EqualTo("Updated"));
            Assert.That(result.LastName, Is.EqualTo("Person"));
            
            _mockPersonRepository.Verify(r => r.Update(id, It.IsAny<Person>()), Times.Once);
        }

        [Test]
        public void Update_WithInvalidId_ReturnsNull()
        {
            // Arrange
            int id = 99;
            var personUpdateDto = new PersonUpdateDto
            {
                Id = id,
                FirstName = "Updated",
                LastName = "Person"
            };

            _mockPersonRepository.Setup(r => r.GetById(id)).Returns((Person?)null);

            // Act
            var result = _personService.Update(id, personUpdateDto);

            // Assert
            Assert.That(result, Is.Null);
            _mockPersonRepository.Verify(r => r.Update(id, It.IsAny<Person>()), Times.Never);
        }

        [Test]
        public void Delete_WithValidId_ReturnsTrue()
        {
            // Arrange
            int id = 1;
            _mockPersonRepository.Setup(r => r.Delete(id)).Returns(true);

            // Act
            var result = _personService.Delete(id);

            // Assert
            Assert.That(result, Is.True);
            _mockPersonRepository.Verify(r => r.Delete(id), Times.Once);
        }
        
        [Test]
        public void Delete_WithInvalidId_ReturnsFalse()
        {
            // Arrange
            int id = 99;
            _mockPersonRepository.Setup(r => r.Delete(id)).Returns(false);

            // Act
            var result = _personService.Delete(id);

            // Assert
            Assert.That(result, Is.False);
            _mockPersonRepository.Verify(r => r.Delete(id), Times.Once);
        }

        [Test]
        public void FilterByBirthYear_WithInvalidCondition_ThrowsArgumentException()
        {
            // Arrange
            _mockPersonRepository.Setup(r => r.GetAll()).Returns(_testPeople);
            string condition = "invalid";
            int year = 1990;

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => _personService.FilterByBirthYear(condition, year));
            Assert.That(ex.Message, Is.EqualTo("Invalid condition parameter"));
        }
    }
} 
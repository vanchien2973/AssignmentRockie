using Moq;
using MVC_NET_Core_Assignment_1.Data;
using MVC_NET_Core_Assignment_1.Models;
using MVC_NET_Core_Assignment_1.Repositories;

namespace MVC_NET_Core_Assignment_2.UnitTests
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
        public void Constructor_InitializesNextIdCorrectly()
        {
            // Arrange
            var testData = new List<Person>
            {
                new Person { Id = 5 },
                new Person { Id = 10 }
            };
            var mockData = new Mock<IDummyData>();
            mockData.Setup(m => m.GetDummyData()).Returns(testData);

            // Act
            var repository = new PersonRepository(mockData.Object);
            var newPerson = new Person { FirstName = "Test" };
            var result = repository.Create(newPerson);

            // Assert
            Assert.That(result.Id, Is.EqualTo(3));
            mockData.Verify(m => m.GetDummyData(), Times.Once);
        }

        [Test]
        public void Constructor_WithEmptyData_InitializesNextIdToOne()
        {
            // Arrange
            var emptyData = new List<Person>();
            var mockData = new Mock<IDummyData>();
            mockData.Setup(m => m.GetDummyData()).Returns(emptyData);

            // Act
            var repository = new PersonRepository(mockData.Object);
            var newPerson = new Person { FirstName = "Test" };
            var result = repository.Create(newPerson);

            // Assert
            Assert.That(result.Id, Is.EqualTo(1));
            mockData.Verify(m => m.GetDummyData(), Times.Once);
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
                BirthPlace = "Hue",
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
        public void Create_SetsDateTimeFields()
        {
            // Arrange
            var beforeTest = DateTime.Now;
            var newPerson = new Person
            {
                FirstName = "Another",
                LastName = "Person"
            };

            // Act
            var result = _repository.Create(newPerson);
            var afterTest = DateTime.Now;

            // Assert
            Assert.That(result.CreatedAt, Is.GreaterThanOrEqualTo(beforeTest));
            Assert.That(result.CreatedAt, Is.LessThanOrEqualTo(afterTest));
            Assert.That(result.UpdatedAt, Is.GreaterThanOrEqualTo(beforeTest));
            Assert.That(result.UpdatedAt, Is.LessThanOrEqualTo(afterTest));
            Assert.That((result.UpdatedAt - result.CreatedAt).TotalMilliseconds, Is.LessThan(100));
        }

        [Test]
        public void Create_AddsToCollection()
        {
            // Arrange
            var countBefore = _repository.GetAll().Count();
            var newPerson = new Person { FirstName = "Test", LastName = "User" };

            // Act
            _repository.Create(newPerson);
            var countAfter = _repository.GetAll().Count();

            // Assert
            Assert.That(countAfter, Is.EqualTo(countBefore + 1));
            Assert.That(_repository.GetAll().Any(p => p.FirstName == "Test" && p.LastName == "User"), Is.True);
        }

        [Test]
        public void Update_WithValidId_UpdatesPersonAndReturnsUpdatedPerson()
        {
            // Arrange
            var id = 1;
            var beforeUpdate = DateTime.Now;
            var personToUpdate = new Person
            {
                FirstName = "Updated",
                LastName = "Person",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                PhoneNumber = "9998887777",
                BirthPlace = "Can Tho",
                IsGraduated = false
            };

            // Act
            var result = _repository.Update(id, personToUpdate);
            var afterUpdate = DateTime.Now;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.FirstName, Is.EqualTo("Updated"));
            Assert.That(result.LastName, Is.EqualTo("Person"));
            Assert.That(result.PhoneNumber, Is.EqualTo("9998887777"));
            Assert.That(result.BirthPlace, Is.EqualTo("Can Tho"));
            Assert.That(result.IsGraduated, Is.EqualTo(false));
            Assert.That(result.UpdatedAt, Is.GreaterThanOrEqualTo(beforeUpdate));
            Assert.That(result.UpdatedAt, Is.LessThanOrEqualTo(afterUpdate));
        }

        [Test]
        public void Update_SetsUpdatedAtToCurrentTime()
        {
            // Arrange
            var id = 1;
            var beforeUpdate = DateTime.Now;
            var personToUpdate = new Person
            {
                FirstName = "Updated",
                LastName = "Person",
            };

            // Act
            var result = _repository.Update(id, personToUpdate);
            var afterUpdate = DateTime.Now;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.UpdatedAt, Is.GreaterThanOrEqualTo(beforeUpdate));
            Assert.That(result.UpdatedAt, Is.LessThanOrEqualTo(afterUpdate));
        }

        [Test]
        public void Update_DoesNotChangeCreatedAt()
        {
            // Arrange
            var id = 1;
            var originalCreatedAt = _repository.GetById(id)!.CreatedAt;
            var personToUpdate = new Person
            {
                FirstName = "Updated Again",
                LastName = "Person",
            };

            // Act
            var result = _repository.Update(id, personToUpdate);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.CreatedAt, Is.EqualTo(originalCreatedAt));
        }

        [Test]
        public void Update_UpdatesAllProperties()
        {
            // Arrange
            var id = 1;
            var newDateOfBirth = new DateTime(1991, 2, 2);
            var originalPerson = _repository.GetById(id);
            Assert.That(originalPerson, Is.Not.Null, "Setup failed: Person not found");
            
            var personToUpdate = new Person
            {
                FirstName = "Complete",
                LastName = "Update",
                Gender = "Non-binary",
                DateOfBirth = newDateOfBirth,
                PhoneNumber = "1112223333",
                BirthPlace = "Hai Phong",
                IsGraduated = false
            };

            // Act
            var result = _repository.Update(id, personToUpdate);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.FirstName, Is.EqualTo("Complete"));
            Assert.That(result.LastName, Is.EqualTo("Update"));
            Assert.That(result.Gender, Is.EqualTo("Non-binary"));
            Assert.That(result.DateOfBirth, Is.EqualTo(newDateOfBirth));
            Assert.That(result.PhoneNumber, Is.EqualTo("1112223333"));
            Assert.That(result.BirthPlace, Is.EqualTo("Hai Phong"));
            Assert.That(result.IsGraduated, Is.EqualTo(false));
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
        public void Delete_RemovesCorrectPerson()
        {
            // Arrange
            var idToDelete = 1;
            var personToDelete = _repository.GetById(idToDelete);
            Assert.That(personToDelete, Is.Not.Null, "Setup failed: Person not found");

            // Act
            var result = _repository.Delete(idToDelete);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(_repository.GetAll().Any(p => p.Id == idToDelete), Is.False);
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

        [Test]
        public void Delete_DoesNotChangeCollectionOnInvalidId()
        {
            // Arrange
            var collectionBefore = _repository.GetAll().ToList();
            
            // Act
            _repository.Delete(99);
            var collectionAfter = _repository.GetAll().ToList();
            
            // Assert
            Assert.That(collectionAfter.Count, Is.EqualTo(collectionBefore.Count));
            for (int i = 0; i < collectionBefore.Count; i++)
            {
                Assert.That(collectionAfter[i].Id, Is.EqualTo(collectionBefore[i].Id));
                Assert.That(collectionAfter[i].FirstName, Is.EqualTo(collectionBefore[i].FirstName));
                Assert.That(collectionAfter[i].LastName, Is.EqualTo(collectionBefore[i].LastName));
            }
        }

        [Test]
        public void Delete_MultipleItems_ReducesCollectionSize()
        {
            // Arrange
            var initialCount = _repository.GetAll().Count();
            
            // Act
            _repository.Delete(1);
            _repository.Delete(2);
            var finalCount = _repository.GetAll().Count();
            
            // Assert
            Assert.That(finalCount, Is.EqualTo(initialCount - 2));
            Assert.That(_repository.GetAll().Count(), Is.EqualTo(0));
        }
    }
} 
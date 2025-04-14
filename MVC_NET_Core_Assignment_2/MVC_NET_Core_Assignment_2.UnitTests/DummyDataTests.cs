using MVC_NET_Core_Assignment_1.Data;
using MVC_NET_Core_Assignment_1.Models;

namespace MVC_NET_Core_Assignment_2.UnitTests
{
    [TestFixture]
    public class DummyDataTests
    {
        private DummyData _dummyData;

        [SetUp]
        public void Setup()
        {
            _dummyData = new DummyData();
        }

        [Test]
        public void GetDummyData_ReturnsNonEmptyList()
        {
            // Act
            var result = _dummyData.GetDummyData();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetDummyData_ReturnsCorrectNumberOfItems()
        {
            // Act
            var result = _dummyData.GetDummyData();

            // Assert
            Assert.That(result.Count, Is.GreaterThanOrEqualTo(10));
        }

        [Test]
        public void GetDummyData_ReturnsValidPeopleWithAllPropertiesSet()
        {
            // Act
            var result = _dummyData.GetDummyData();

            // Assert
            Assert.That(result, Is.Not.Null);
            foreach (var person in result)
            {
                Assert.That(person.Id, Is.GreaterThan(0));
                Assert.That(person.FirstName, Is.Not.Null.And.Not.Empty);
                Assert.That(person.LastName, Is.Not.Null.And.Not.Empty);
                Assert.That(person.Gender, Is.Not.Null.And.Not.Empty);
                Assert.That(person.DateOfBirth, Is.Not.EqualTo(default(DateTime)));
                Assert.That(person.PhoneNumber, Is.Not.Null);
                Assert.That(person.BirthPlace, Is.Not.Null);
                Assert.That(person.CreatedAt, Is.Not.EqualTo(default(DateTime)));
                Assert.That(person.UpdatedAt, Is.Not.EqualTo(default(DateTime)));
            }
        }

        [Test]
        public void GetDummyData_ContainsVarietyOfGenders()
        {
            // Act
            var result = _dummyData.GetDummyData();

            // Assert
            var genders = result.Select(p => p.Gender).Distinct().ToList();
            Assert.That(genders.Count, Is.GreaterThanOrEqualTo(2), "At least 2 different gender values");
        }

        [Test]
        public void GetDummyData_ContainsVarietyOfBirthPlaces()
        {
            // Act
            var result = _dummyData.GetDummyData();

            // Assert
            var birthPlaces = result.Select(p => p.BirthPlace).Distinct().ToList();
            Assert.That(birthPlaces.Count, Is.GreaterThanOrEqualTo(3), "At least 3 different birth places of birth");
        }

        [Test]
        public void GetDummyData_HasUniqueIds()
        {
            // Act
            var result = _dummyData.GetDummyData();

            // Assert
            var uniqueIds = result.Select(p => p.Id).Distinct().Count();
            Assert.That(uniqueIds, Is.EqualTo(result.Count), "Each person must have a unique ID");
        }

        [Test]
        public void GetDummyData_HasConsistentFullName()
        {
            // Act
            var result = _dummyData.GetDummyData();

            // Assert
            foreach (var person in result)
            {
                Assert.That(person.FullName, Is.EqualTo($"{person.LastName} {person.FirstName}"));
            }
        }

        [Test]
        public void GetDummyData_AllTimeStampsAreValid()
        {
            // Act
            var result = _dummyData.GetDummyData();

            // Assert
            var now = DateTime.Now;
            foreach (var person in result)
            {
                Assert.That(person.CreatedAt, Is.LessThanOrEqualTo(now));
                Assert.That(person.UpdatedAt, Is.LessThanOrEqualTo(now));
                Assert.That(person.UpdatedAt, Is.GreaterThanOrEqualTo(person.CreatedAt));
            }
        }

        [Test]
        public void GetDummyData_PersonAgeRangeIsReasonable()
        {
            // Act
            var result = _dummyData.GetDummyData();

            // Assert
            var currentYear = DateTime.Now.Year;
            foreach (var person in result)
            {
                var age = currentYear - person.DateOfBirth.Year;
                Assert.That(age, Is.GreaterThanOrEqualTo(16).And.LessThanOrEqualTo(100));
            }
        }
    }
} 
using Microsoft.AspNetCore.Mvc;
using Moq;
using MVC_NET_Core_Assignment_1.Controllers;
using MVC_NET_Core_Assignment_1.DTOs.Person;
using MVC_NET_Core_Assignment_1.Helpers;
using MVC_NET_Core_Assignment_1.Services.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MVC_NET_Core_Assignment_2.Tests
{
    [TestFixture]
    public class PersonControllerTests
    {
        private Mock<IPersonService> _mockPersonService;
        private PersonController _controller;

        [SetUp]
        public void Setup()
        {
            _mockPersonService = new Mock<IPersonService>();
            _controller = new PersonController(_mockPersonService.Object);
        }
        
        [TearDown]
        public void TearDown()
        {
            _controller?.Dispose();
        }

        [Test]
        public void Index_ReturnsViewWithPaginatedPeople()
        {
            // Arrange
            var pageIndex = 1;
            var pageSize = 10;
            var paginatedList = new PaginatedList<PersonDto>(
                new List<PersonDto> { new() { Id = 1, FirstName = "John", LastName = "Doe" } },
                1, pageIndex, pageSize);
            
            _mockPersonService.Setup(s => s.GetPaginatedPeople(pageIndex, pageSize))
                .Returns(paginatedList);

            // Act
            var result = _controller.Index(pageIndex);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.InstanceOf<PaginatedList<PersonDto>>());
            var model = (PaginatedList<PersonDto>)viewResult.Model;
            Assert.That(model.Count, Is.EqualTo(1));
        }

        [Test]
        public void MaleMembers_ReturnsViewWithPaginatedMaleMembers()
        {
            // Arrange
            var pageIndex = 1;
            var pageSize = 10;
            var paginatedList = new PaginatedList<PersonDto>(
                new List<PersonDto> { new() { Id = 1, FirstName = "John", LastName = "Doe", Gender = "Male" } },
                1, pageIndex, pageSize);
            
            _mockPersonService.Setup(s => s.GetPaginatedMaleMembers(pageIndex, pageSize))
                .Returns(paginatedList);

            // Act
            var result = _controller.MaleMembers(pageIndex);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.InstanceOf<PaginatedList<PersonDto>>());
            var model = (PaginatedList<PersonDto>)viewResult.Model;
            Assert.That(model.Count, Is.EqualTo(1));
            Assert.That(model[0].Gender, Is.EqualTo("Male"));
        }

        [Test]
        public void GetOldestMember_WhenMembersExist_ReturnsViewWithOldestMember()
        {
            // Arrange
            var oldestMember = new PersonDto { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 1) };
            _mockPersonService.Setup(s => s.GetOldestMember()).Returns(oldestMember);

            // Act
            var result = _controller.GetOldestMember();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.EqualTo(oldestMember));
        }

        [Test]
        public void GetOldestMember_WhenNoMembers_ReturnsNotFound()
        {
            // Arrange
            _mockPersonService.Setup(s => s.GetOldestMember()).Returns((PersonDto?)null);

            // Act
            var result = _controller.GetOldestMember();

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public void GetFullNames_ReturnsViewWithFullNames()
        {
            // Arrange
            var fullNames = new List<PersonFullNameDto>
            {
                new() { FullName = "Doe John" }
            };
            _mockPersonService.Setup(s => s.GetFullNames()).Returns(fullNames);

            // Act
            var result = _controller.GetFullNames();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.EquivalentTo(fullNames));
        }

        [Test]
        public void FilterByBirthYear_WithValidParameters_ReturnsViewWithFilteredPeople()
        {
            // Arrange
            var condition = "equal";
            var year = 2000;
            var filteredPeople = new List<PersonDto>
            {
                new() { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(2000, 1, 1) }
            };
            _mockPersonService.Setup(s => s.FilterByBirthYear(condition, year)).Returns(filteredPeople);

            // Act
            var result = _controller.FilterByBirthYear(condition, year);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.EquivalentTo(filteredPeople));
            Assert.That(viewResult.ViewData["Error"], Is.Null);
        }

        [Test]
        public void FilterByBirthYear_WithMissingParameters_ReturnsViewWithError()
        {
            // Act
            var result = _controller.FilterByBirthYear(null, 2000);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewData["Error"], Is.EqualTo("Condition and year parameters are required"));
            Assert.That(viewResult.Model, Is.Empty);
        }

        [Test]
        public void FilterByBirthYear_WithInvalidCondition_ReturnsViewWithError()
        {
            // Arrange
            var condition = "invalid";
            var year = 2000;
            var exceptionMessage = "Invalid condition";
            _mockPersonService.Setup(s => s.FilterByBirthYear(condition, year))
                .Throws(new ArgumentException(exceptionMessage));

            // Act
            var result = _controller.FilterByBirthYear(condition, year);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.ViewData["Error"], Is.EqualTo(exceptionMessage));
            Assert.That(viewResult.Model, Is.Empty);
        }

        [Test]
        public void ExportToExcel_WhenDataExists_ReturnsFileResult()
        {
            // Arrange
            var excelBytes = new byte[] { 1, 2, 3 };
            _mockPersonService.Setup(s => s.ExportToExcel()).Returns(excelBytes);

            // Act
            var result = _controller.ExportToExcel();

            // Assert
            Assert.That(result, Is.InstanceOf<FileContentResult>());
            var fileResult = (FileContentResult)result;
            Assert.That(fileResult.FileContents, Is.EqualTo(excelBytes));
            Assert.That(fileResult.ContentType, Is.EqualTo("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
            Assert.That(fileResult.FileDownloadName, Does.Contain("People_"));
        }

        [Test]
        public void ExportToExcel_WhenNoData_ReturnsNotFound()
        {
            // Arrange
            var emptyBytes = new byte[0];
            _mockPersonService.Setup(s => s.ExportToExcel()).Returns(emptyBytes);

            // Act
            var result = _controller.ExportToExcel();

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public void ExportToExcel_WhenExceptionOccurs_ReturnsStatusCode500()
        {
            // Arrange
            _mockPersonService.Setup(s => s.ExportToExcel()).Throws<Exception>();

            // Act
            var result = _controller.ExportToExcel();

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var statusCodeResult = (ObjectResult)result;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(500));
        }

        [Test]
        public void Details_WhenPersonExists_ReturnsViewWithPerson()
        {
            // Arrange
            var id = 1;
            var person = new PersonDto { Id = id, FirstName = "John", LastName = "Doe" };
            _mockPersonService.Setup(s => s.GetById(id)).Returns(person);

            // Act
            var result = _controller.Details(id);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.EqualTo(person));
        }

        [Test]
        public void Details_WhenPersonDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            _mockPersonService.Setup(s => s.GetById(id)).Returns((PersonDto?)null);

            // Act
            var result = _controller.Details(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void Create_Get_ReturnsView()
        {
            // Act
            var result = _controller.Create();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void Create_Post_WithValidModel_RedirectsToIndex()
        {
            // Arrange
            var personDto = new PersonCreateDto
            {
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                PhoneNumber = "1234567890",
                BirthPlace = "City",
                IsGraduated = true
            };
            
            _mockPersonService.Setup(s => s.Create(personDto))
                .Returns(new PersonDto { Id = 1, FirstName = "John", LastName = "Doe" });

            // Act
            var result = _controller.Create(personDto);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = (RedirectToActionResult)result;
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Create_Post_WithInvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var personDto = new PersonCreateDto();
            _controller.ModelState.AddModelError("FirstName", "Required");

            // Act
            var result = _controller.Create(personDto);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.EqualTo(personDto));
        }

        [Test]
        public void Edit_Get_WhenPersonExists_ReturnsViewWithPerson()
        {
            // Arrange
            var id = 1;
            var person = new PersonUpdateDto { Id = id, FirstName = "John", LastName = "Doe" };
            _mockPersonService.Setup(s => s.GetForUpdate(id)).Returns(person);

            // Act
            var result = _controller.Edit(id);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.EqualTo(person));
        }

        [Test]
        public void Edit_Get_WhenPersonDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            _mockPersonService.Setup(s => s.GetForUpdate(id)).Returns((PersonUpdateDto?)null);

            // Act
            var result = _controller.Edit(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void Edit_Post_WithValidModel_RedirectsToIndex()
        {
            // Arrange
            var id = 1;
            var personDto = new PersonUpdateDto
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 1, 1),
                PhoneNumber = "1234567890",
                BirthPlace = "City",
                IsGraduated = true
            };
            
            _mockPersonService.Setup(s => s.Update(id, personDto))
                .Returns(new PersonDto { Id = id, FirstName = "John", LastName = "Doe" });

            // Act
            var result = _controller.Edit(id, personDto);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = (RedirectToActionResult)result;
            Assert.That(redirectResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public void Edit_Post_WithInvalidModel_ReturnsViewWithModel()
        {
            // Arrange
            var id = 1;
            var personDto = new PersonUpdateDto { Id = id };
            _controller.ModelState.AddModelError("FirstName", "Required");

            // Act
            var result = _controller.Edit(id, personDto);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.EqualTo(personDto));
        }

        [Test]
        public void Edit_Post_WithMismatchedId_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            var personDto = new PersonUpdateDto { Id = 2 };

            // Act
            var result = _controller.Edit(id, personDto);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void Edit_Post_WhenUpdateReturnsNull_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            var personDto = new PersonUpdateDto { Id = id };
            
            _mockPersonService.Setup(s => s.Update(id, personDto))
                .Returns((PersonDto?)null);

            // Act
            var result = _controller.Edit(id, personDto);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void Delete_Get_WhenPersonExists_ReturnsViewWithPerson()
        {
            // Arrange
            var id = 1;
            var person = new PersonDto { Id = id, FirstName = "John", LastName = "Doe" };
            _mockPersonService.Setup(s => s.GetById(id)).Returns(person);

            // Act
            var result = _controller.Delete(id);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.EqualTo(person));
        }

        [Test]
        public void Delete_Get_WhenPersonDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            _mockPersonService.Setup(s => s.GetById(id)).Returns((PersonDto?)null);

            // Act
            var result = _controller.Delete(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void DeleteConfirmed_WhenPersonExists_RedirectsToDeleteConfirmation()
        {
            // Arrange
            var id = 1;
            var person = new PersonDto 
            { 
                Id = id, 
                FirstName = "John", 
                LastName = "Doe",
            };
            
            _mockPersonService.Setup(s => s.GetById(id)).Returns(person);
            _mockPersonService.Setup(s => s.Delete(id)).Returns(true);

            // Act
            var result = _controller.DeleteConfirmed(id);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectResult = (RedirectToActionResult)result;
            Assert.That(redirectResult.ActionName, Is.EqualTo("DeleteConfirmation"));
            Assert.That(redirectResult.RouteValues?["id"], Is.EqualTo(id));
            Assert.That(redirectResult.RouteValues?["name"], Is.EqualTo(person.FullName));
        }

        [Test]
        public void DeleteConfirmed_WhenPersonDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            _mockPersonService.Setup(s => s.GetById(id)).Returns((PersonDto?)null);

            // Act
            var result = _controller.DeleteConfirmed(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void DeleteConfirmed_WhenDeleteFails_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            var person = new PersonDto { Id = id, FirstName = "John", LastName = "Doe" };
            
            _mockPersonService.Setup(s => s.GetById(id)).Returns(person);
            _mockPersonService.Setup(s => s.Delete(id)).Returns(false);

            // Act
            var result = _controller.DeleteConfirmed(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public void DeleteConfirmation_ReturnsViewWithModel()
        {
            // Arrange
            var id = 1;
            var name = "John Doe";

            // Act
            var result = _controller.DeleteConfirmation(id, name);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = (ViewResult)result;
            Assert.That(viewResult.Model, Is.InstanceOf<PersonDto>());
            var model = (PersonDto)viewResult.Model;
            Assert.That(model.Id, Is.EqualTo(id));
            Assert.That(model.FirstName, Is.EqualTo(name));
        }
    }
} 
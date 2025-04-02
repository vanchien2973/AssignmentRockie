using Microsoft.AspNetCore.Mvc;
using MVC_NET_Core_Assignment_1.DTOs;
using MVC_NET_Core_Assignment_1.Models;
using MVC_NET_Core_Assignment_1.Services.Interfaces;

namespace MVC_NET_Core_Assignment_1.Controllers
{
    [Route("NashTech/Rookies")]
    [ApiController]
    public class PersonController(IPersonService personService) : Controller
    {
        [HttpGet]
        public IActionResult Index(int pageIndex = 1)
        {
            const int pageSize = 10;
            var people = personService.GetPaginatedPeople(pageIndex, pageSize);
            return View(people);
        }

        [HttpGet("MaleMembers")]
        public IActionResult MaleMembers(int pageIndex = 1)
        {
            const int pageSize = 10;
            return View(personService.GetPaginatedMaleMembers(pageIndex, pageSize));
        }

        [HttpGet("OldestMember")]
        public IActionResult GetOldestMember()
        {
            var oldest = personService.GetOldestMember();
            return oldest != null ? View(oldest) : NotFound("No members found");
        }

        [HttpGet("FullNames")]
        public IActionResult GetFullNames()
        {
            return View(personService.GetFullNames());
        }

        [HttpGet("FilterByBirthYear")]
        public IActionResult FilterByBirthYear([FromQuery] string? condition, [FromQuery] int? year = 2000)
        {
            if (string.IsNullOrEmpty(condition) || year == null)
            {
                ViewData["Error"] = "Condition and year parameters are required";
                return View(Enumerable.Empty<PersonDto>());
            }

            try
            {
                return View(personService.FilterByBirthYear(condition, year.Value));
            }
            catch (ArgumentException ex)
            {
                ViewData["Error"] = ex.Message;
                return View(Enumerable.Empty<PersonDto>());
            }
            catch (Exception)
            {
                ViewData["Error"] = "An error occurred while processing your request";
                return View(Enumerable.Empty<PersonDto>());
            }
        }

        [HttpGet("ExportToExcel")]
        public IActionResult ExportToExcel()
        {
            try
            {
                var bytes = personService.ExportToExcel();
                if (bytes.Length == 0)
                {
                    return NotFound("No data available to export");
                }

                return File(bytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    $"People_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while generating the Excel file");
            }
        }

        [HttpGet("Details/{id:int}")]
        public IActionResult Details(int id)
        {
            var person = personService.GetById(id);
            return person == null ? NotFound() : View(person);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] PersonCreateDto person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            personService.Create(person);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var person = personService.GetById(id);
            if (person == null) return NotFound();

            var personUpdateDto = new PersonUpdateDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                BirthPlace = person.BirthPlace,
                IsGraduated = person.IsGraduated
            };
            return View(personUpdateDto);
        }

        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [FromForm] PersonUpdateDto person)
        {
            if (id != person.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(person);
            }

            var updatedPerson = personService.Update(id, person);
            return updatedPerson == null ? NotFound() : RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var person = personService.GetById(id);
            return person == null ? NotFound() : View(person);
        }

        [HttpPost("Delete/{id:int}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var personToDelete = personService.GetById(id);
            if (personToDelete == null) return NotFound();

            if (!personService.Delete(id)) return NotFound();

            return RedirectToAction("DeleteConfirmation", new
            {
                id = personToDelete.Id,
                name = personToDelete.FullName
            });
        }

        [HttpGet("DeleteConfirmation")]
        public IActionResult DeleteConfirmation(int id, string name)
        {
            var model = new PersonDto { Id = id, FirstName = name };
            return View(model);
        }
    }
}
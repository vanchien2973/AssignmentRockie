using Microsoft.AspNetCore.Mvc;
using MVC_NET_Core_Assignment_1.Models;
using MVC_NET_Core_Assignment_1.Repositories;
using MVC_NET_Core_Assignment_1.Services;

namespace MVC_NET_Core_Assignment_1.Controllers
{
    [Route("NashTech/Rookies")]
    [ApiController]
    public class PersonController(IPersonService service, IPersonRepository personRepository) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var people = personRepository.GetAllPeople();
            return View(people);
        }
        
        [HttpGet("MaleMembers")]
        public ActionResult<IEnumerable<Person>> GetMaleMembers()
        {
            return Ok(service.GetMaleMembers());
        }
        
        [HttpGet("OldestMember")]
        public ActionResult<Person> GetOldestMember()
        {
            var oldest = service.GetOldestMember();
            return oldest != null ? Ok(oldest) : NotFound("No members found");
        }
        
        [HttpGet("FullNames")]
        public ActionResult<IEnumerable<string>> GetFullNames()
        {
            return Ok(service.GetFullNames());
        }
        
        [HttpGet("FilterByBirthYear")]
        public ActionResult<IEnumerable<Person>> FilterByBirthYear(
            [FromQuery] string action, 
            [FromQuery] int year = 2000)
        {
            try
            {
                return Ok(service.FilterByBirthYear(action, year));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("ExportToExcel")]
        public IActionResult ExportToExcel()
        {
            var bytes = service.ExportToExcel();
            return File(bytes, "text/csv", "RookiesPeople.csv");
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }

            personRepository.AddPerson(person);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Edit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var person = personRepository.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost("Edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(person);
            }

            personRepository.UpdatePerson(person);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var person = personRepository.GetPersonById(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost("Delete/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            personRepository.DeletePerson(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

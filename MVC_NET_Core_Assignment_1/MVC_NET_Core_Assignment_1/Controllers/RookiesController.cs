using Microsoft.AspNetCore.Mvc;
using MVC_NET_Core_Assignment_1.Data;
using MVC_NET_Core_Assignment_1.Models;
using MVC_NET_Core_Assignment_1.Services;

namespace MVC_NET_Core_Assignment_1.Controllers
{
    [Route("NashTech/Rookies")]
    [ApiController]
    public class RookiesController(IRookiesService service) : ControllerBase
    {
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
    }
}

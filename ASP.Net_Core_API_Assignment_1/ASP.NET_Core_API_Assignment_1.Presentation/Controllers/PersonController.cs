using System.ComponentModel.DataAnnotations;
using ASP.NET_Core_API_Assignment_1.Application.DTOs.Person;
using ASP.NET_Core_API_Assignment_1.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_API_Assignment_1.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonController(IPersonService personService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonResponseDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<PersonResponseDto>>> GetAllPersons()
    {
        try
        {
            var persons = await personService.GetAllPersonsAsync();
            return Ok(persons);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while retrieving persons", error = ex.Message });
        }
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonResponseDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PersonResponseDto>> GetPersonById(Guid id)
    {
        try
        {
            var person = await personService.GetPersonByIdAsync(id);
            return Ok(person);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while retrieving the person", error = ex.Message });
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PersonResponseDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<PersonResponseDto>> CreatePerson([FromBody] CreatePersonRequestDto personDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid model state", errors = ModelState });
        }

        try
        {
            var createdPerson = await personService.AddPersonAsync(personDto);
            
            return CreatedAtAction(
                actionName: nameof(GetPersonById),
                routeValues: new { id = createdPerson.Id },
                value: createdPerson);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { message = "Validation error", error = ex.Message });
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(new { message = "Invalid data", error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while creating the person", error = ex.Message });
        }
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdatePerson(Guid id, [FromBody] UpdatePersonRequestDto personDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = "Invalid model state", errors = ModelState });
        }

        try
        {
            await personService.UpdatePersonAsync(id, personDto);
            return NoContent();
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { message = "Validation error", error = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while updating the person", error = ex.Message });
        }
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        try
        {
            await personService.DeletePersonAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while deleting the person", error = ex.Message });
        }
    }

    [HttpGet("filter")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PersonResponseDto>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<IEnumerable<PersonResponseDto>>> GetAllPersonsFilter(
        [FromQuery] string? name,
        [FromQuery] string? gender,
        [FromQuery] string? birthPlace)
    {
        try
        {
            var filteredPeople = await personService.FilterPersonAsync(
                name,
                gender,
                birthPlace);
        
            return Ok(filteredPeople);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { message = "Validation error", error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while filtering persons", error = ex.Message });
        }
    }
}
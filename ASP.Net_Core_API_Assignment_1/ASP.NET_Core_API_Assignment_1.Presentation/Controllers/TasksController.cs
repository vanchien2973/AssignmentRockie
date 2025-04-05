using ASP.NET_Core_API_Assignment_1.Application.DTOs;
using ASP.NET_Core_API_Assignment_1.Application.DTOs.TaskItem;
using ASP.NET_Core_API_Assignment_1.Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_API_Assignment_1.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TasksController(
    ITaskService taskService,
    // IMapper mapper,
    ILogger<TasksController> logger)
    : ControllerBase
{
    // private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TaskItemDto>))]
    public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetAllTasks()
    {
        var tasks = await taskService.GetAllTasksAsync();
        return Ok(tasks);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TaskItemDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TaskItemDto>> GetTaskById(Guid id)
    {
        var task = await taskService.GetTaskByIdAsync(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TaskItemDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TaskItemDto>> CreateTask([FromBody] CreateTaskItemDto taskItemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var createdTask = await taskService.CreateTaskAsync(taskItemDto);
            
            return CreatedAtAction(
                actionName: nameof(GetTaskById),
                routeValues: new { id = createdTask.Id },
                value: createdTask);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error creating task");
            return BadRequest("Error creating task");
        }
    }
    
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTask(Guid id, [FromBody] UpdateTaskItemDto taskItemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await taskService.UpdateTaskAsync(id, taskItemDto);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error updating task");
            return BadRequest("Error updating task");
        }
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        try
        {
            await taskService.DeleteTaskAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
    
    [HttpPost("bulk")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> BulkAddTasks([FromBody] BulkTaskItemDto bulkTaskItemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await taskService.BulkAddTasksAsync(bulkTaskItemDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in bulk add tasks");
            return BadRequest("Error in bulk add tasks");
        }
    }
    
    [HttpDelete("bulk")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> BulkDeleteTasks([FromBody] BulkDeleteTaskItemDto bulkDeleteTaskItemDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await taskService.BulkDeleteTasksAsync(bulkDeleteTaskItemDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error in bulk delete tasks");
            return BadRequest("Error in bulk delete tasks");
        }
    }
}
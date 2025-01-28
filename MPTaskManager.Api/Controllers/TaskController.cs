using MediatR;
using Microsoft.AspNetCore.Mvc;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Features.Tasks.Commands;
using MPTaskManager.Api.Features.Tasks.Queries;

namespace MPTaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    
    /// <summary>
    /// Method to get all tasks from the database (Not recommended for large databases)
    /// </summary>
    /// <returns>List of tasks</returns>
    [HttpGet]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<IEnumerable<TaskItemResponseDTO>>> GetAllTasks()
    {
        var result = await _mediator.Send(new GetAllTaskItemsQuery());
        return Ok(result);
    }
    
    
    /// <summary>
    /// Method to get all tasks from the database paginated
    /// </summary>
    /// <param name="pageNumber">Page number</param>
    /// <param name="pageSize">Number of items per page</param>
    /// <returns>Page with tasks</returns>
    [HttpGet("paged")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<PagedResultDTO<TaskItemResponseDTO>>> GetAllTasksPaged(int pageNumber = 1, int pageSize = 10)
    {
        var pagedResult = await _mediator.Send(new GetAllTaskItemsPagedQuery(pageNumber, pageSize));
        return Ok(pagedResult);
    }


    /// <summary>
    /// Method to get a task by its id
    /// </summary>
    /// <param name="id">Task id</param>
    /// <returns>Task</returns>
    [HttpGet("{id}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
    public async Task<ActionResult<TaskItemResponseDTO>> GetTaskById(int id)
    {
        var result = await _mediator.Send(new GetTaskItemByIdQuery(id));
        return Ok(result);
    }
    
    /// <summary>
    /// Method to create a task
    /// </summary>
    /// <param name="taskItemCreateRequestDto">Task to create</param>
    /// <remarks>
    /// POST /api/task
    /// ```json
    ///     {
    ///         "title": "Task of the day",
    ///         "description": "This is the task of the day",
    ///         "dueDate": "2022-12-31"
    ///     }
    /// ```
    /// </remarks>
    /// <returns>Task created</returns>
    [HttpPost]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
    public async Task<IActionResult> CreateTaskItem([FromBody] TaskItemCreateRequestDTO taskItemCreateRequestDto)
    {
        var response = await _mediator.Send(new CreateTaskItemCommand(taskItemCreateRequestDto));
        return Ok(response);
    }
    
    /// <summary>
    /// Update a task by its id
    /// </summary>
    /// <param name="id">Task id</param>
    /// <param name="taskItemUpdateRequestDto">Task to update</param>
    /// <remarks>
    /// PUT /api/task/1
    /// ```json
    ///    {
    ///      "title": "Task of the day updated",
    ///      "description": "This is the task of the day updated",
    ///      "dueDate": "2022-12-31",
    ///      "isCompleted": true
    ///   }
    /// ```
    /// </remarks>
    [HttpPut]
    [Route("{id}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
    public async Task<IActionResult> UpdateTaskItem(int id, [FromBody] TaskItemUpdateRequestDTO taskItemUpdateRequestDto)
    {
        var response = await _mediator.Send(new UpdateTaskItemByIdCommand(id, taskItemUpdateRequestDto));
        return Ok(response);
    }
    
    /// <summary>
    /// Delete a task by its id
    /// </summary>
    /// <param name="id">Task id</param>
    /// <returns>Task deleted</returns >
    [HttpDelete]
    [Route("{id}")]
    [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
    public async Task<IActionResult> DeleteTaskItem(int id)
    {
        var response = await _mediator.Send(new DeleteTaskItemByIdCommand(id));
        return Ok(response);
    }
    
}
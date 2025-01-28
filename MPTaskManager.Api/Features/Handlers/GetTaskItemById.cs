using MediatR;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Features.Tasks.Queries;
using MPTaskManager.Api.Models;
using MPTaskManager.Api.Services;

namespace MPTaskManager.Api.Features.Handlers;

public class GetTaskItemById : IRequestHandler<GetTaskItemByIdQuery, TaskItemResponseDTO>
{
    private readonly ITaskItemService _taskItemService;
    private readonly ILogger<GetTaskItemById> _logger;
    
    public GetTaskItemById(ITaskItemService taskItemService, ILogger<GetTaskItemById> logger)
    {
        _taskItemService = taskItemService;
        _logger = logger;
    }

    public async Task<TaskItemResponseDTO> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing command GetTaskItemById.");
        var result = await _taskItemService.GetTaskItemById(request.id);
        _logger.LogInformation("Command GetTaskItemById processed successfully.");
        return result;
    }
}
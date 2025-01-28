using MediatR;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Features.Tasks.Queries;
using MPTaskManager.Api.Models;
using MPTaskManager.Api.Services;

namespace MPTaskManager.Api.Features.Handlers;

public class GetAllTaskItemsHandler : IRequestHandler<GetAllTaskItemsQuery, IEnumerable<TaskItemResponseDTO>>
{
    private readonly ITaskItemService _taskItemService;
    private readonly ILogger<CreateTaskItemHandler> _logger;
    
    public GetAllTaskItemsHandler(ITaskItemService taskItemService, ILogger<CreateTaskItemHandler> logger)
    {
        _taskItemService = taskItemService;
        _logger = logger;
    }
    
    public async Task<IEnumerable<TaskItemResponseDTO>> Handle(GetAllTaskItemsQuery request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing command GetAllTaskItems.");
        // Obtenção de todas as tarefas
        var result = await _taskItemService.GetAllTaskItems();
        _logger.LogInformation("Command GetAllTaskItems processed successfully.");
        return result;
    }
}

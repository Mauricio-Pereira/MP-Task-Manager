using MediatR;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Features.Tasks.Commands;
using MPTaskManager.Api.Services;

namespace MPTaskManager.Api.Features.Handlers;

public class DeleteTaskItemByIdHandler : IRequestHandler<DeleteTaskItemByIdCommand, TaskItemResponseDTO>
{
    private readonly ITaskItemService _taskItemService;
    private readonly ILogger<CreateTaskItemHandler> _logger;
    
    public DeleteTaskItemByIdHandler(ITaskItemService taskItemService, ILogger<CreateTaskItemHandler> logger)
    {
        _taskItemService = taskItemService;
        _logger = logger;
    }
    public async Task<TaskItemResponseDTO> Handle(DeleteTaskItemByIdCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing command DeleteTaskItemById.");
        // Eliminação da tarefa
        var result = await _taskItemService.DeleteTaskItemById(request.Id);
        _logger.LogInformation("Command DeleteTaskItemById processed successfully.");
        return result;
    }
}
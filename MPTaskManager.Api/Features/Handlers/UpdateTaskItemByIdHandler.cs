using MediatR;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Features.Tasks.Commands;
using MPTaskManager.Api.Models;
using MPTaskManager.Api.Services;

namespace MPTaskManager.Api.Features.Handlers;

public class UpdateTaskItemByIdHandler : IRequestHandler<UpdateTaskItemByIdCommand, TaskItemResponseDTO>
{
    private readonly ITaskItemService _taskItemService;
    private readonly ILogger<CreateTaskItemHandler> _logger;
    
    public UpdateTaskItemByIdHandler(ITaskItemService taskItemService, ILogger<CreateTaskItemHandler> logger)
    {
        _taskItemService = taskItemService;
        _logger = logger;
    }
    
    
    public async Task<TaskItemResponseDTO> Handle(UpdateTaskItemByIdCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing command UpdateTaskItemById.");
        // Atualização da tarefa
        var result = await _taskItemService.UpdateTaskItemById(request.Id, request.TaskItemUpdateRequestDto);
        _logger.LogInformation("Command UpdateTaskItemById processed successfully.");
        return result;
    }
}
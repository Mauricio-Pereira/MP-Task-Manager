using MediatR;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Features.Tasks.Commands;
using MPTaskManager.Api.Models;
using MPTaskManager.Api.Repositories;
using MPTaskManager.Api.Services;

namespace MPTaskManager.Api.Features.Handlers;

public class CreateTaskItemHandler : IRequestHandler<CreateTaskItemCommand, TaskItemResponseDTO>
{
    private readonly ITaskItemService _taskItemService;
    private readonly ILogger<CreateTaskItemHandler> _logger;
    
    public CreateTaskItemHandler(ITaskItemService taskItemService, ILogger<CreateTaskItemHandler> logger)
    {
        _taskItemService = taskItemService;
        _logger = logger;
    }
    
    public async Task<TaskItemResponseDTO> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processando comando CreateTaskItem. Titulo: {Titulo}", request.TaskItemCreateRequestDto.Title);
        // Criação da tarefa
        var result = await _taskItemService.CreateTaskItem(request.TaskItemCreateRequestDto);
        _logger.LogInformation("Comando CreateTaskItem processado com sucesso. Id: {Id}", result.Id);
        
        return result;
        
    }
}
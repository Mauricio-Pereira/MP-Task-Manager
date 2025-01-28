using AutoMapper;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Models;
using MPTaskManager.Api.Repositories;
using MPTaskManager.Api.Utils.Exceptions;

namespace MPTaskManager.Api.Services;

public class TaskItemService : ITaskItemService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<TaskItemService> _logger;

    public TaskItemService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TaskItemService> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> GetTotalTaskCountAsync()
    {
        return await _unitOfWork.TaskItemRepository.GetTotalCountAsync();
    }
    public async Task<IEnumerable<TaskItemResponseDTO>> GetAllTaskItems()
    {
        var taskItems = await _unitOfWork.TaskItemRepository.GetAllAsync();
        if (taskItems == null || !taskItems.Any())
        {
            _logger.LogError("No task items found");
            throw new NotFoundException("No task items found");
        }

        _logger.LogInformation("Task items found");
        return taskItems.Select(x => _mapper.Map<TaskItemResponseDTO>(x));
    }

    public async Task<IEnumerable<TaskItemResponseDTO>> GetAllTaskItemsPaged(int pageNumber, int pageSize)
    {
        var taskItems = await _unitOfWork.TaskItemRepository.GetAllPaginatedAsync(pageNumber, pageSize);
        if (taskItems == null || !taskItems.Any())
        {
            _logger.LogError("No task items found");
            throw new NotFoundException("No task items found");
        }

        _logger.LogInformation("Task items found");
        return taskItems.Select(x => _mapper.Map<TaskItemResponseDTO>(x));
    }

    public async Task<TaskItemResponseDTO> GetTaskItemById(int id)
    {
        var taskItem = await _unitOfWork.TaskItemRepository.GetByTaskIdAsync(id);
        if (taskItem == null)
        {
            _logger.LogError("Task item not found. Id: {Id}", id);
            throw new NotFoundException("Task item not found");
        }

        _logger.LogInformation("Task item found. Id: {Id}", id);
        return _mapper.Map<TaskItemResponseDTO>(taskItem);
    }

    public async Task<TaskItemResponseDTO> CreateTaskItem(TaskItemCreateRequestDTO taskItemCreateRequestDto)
    {
        if (taskItemCreateRequestDto == null)
        {
            _logger.LogError("Task item is null");
            throw new BadRequestException("Task item is null");
        }

        var taskItem = _mapper.Map<TaskItem>(taskItemCreateRequestDto);
        taskItem.IsDone = false;
        taskItem.CreatedDate = DateTime.UtcNow;
        await _unitOfWork.TaskItemRepository.PostAsync(taskItem);
        await _unitOfWork.Commit();

        _logger.LogInformation("Task item created. Id: {Id}", taskItem.Id);
        return _mapper.Map<TaskItemResponseDTO>(taskItem);
    }

    public async Task<TaskItemResponseDTO> UpdateTaskItemById(int id, TaskItemUpdateRequestDTO taskItemUpdateRequestDto)
    {
        if (taskItemUpdateRequestDto == null)
        {
            _logger.LogError("Task item is null");
            throw new BadRequestException("Task item is null");
        }

        var taskItem = await _unitOfWork.TaskItemRepository.GetByTaskIdAsync(id);
        if (taskItem == null)
        {
            _logger.LogError("Task item not found. Id: {Id}", id);
            throw new NotFoundException("Task item not found");
        }

        _mapper.Map(taskItemUpdateRequestDto, taskItem);
        await _unitOfWork.Commit();

        _logger.LogInformation("Task item updated. Id: {Id}", id);
        return _mapper.Map<TaskItemResponseDTO>(taskItem);
    }

    public async Task<TaskItemResponseDTO> DeleteTaskItemById(int id)
    {
        var taskItem = await _unitOfWork.TaskItemRepository.GetByTaskIdAsync(id);
        if (taskItem == null)
        {
            _logger.LogError("Task item not found. Id: {Id}", id);
            throw new NotFoundException("Task item not found");
        }

        await _unitOfWork.TaskItemRepository.DeleteAsync(id);
        await _unitOfWork.Commit();

        _logger.LogInformation("Task item deleted. Id: {Id}", id);
        return _mapper.Map<TaskItemResponseDTO>(taskItem);
    }
}
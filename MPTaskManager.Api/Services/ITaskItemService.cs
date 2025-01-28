using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Models;

namespace MPTaskManager.Api.Services;

public interface ITaskItemService
{
    Task<IEnumerable<TaskItemResponseDTO>> GetAllTaskItems();
    Task<IEnumerable<TaskItemResponseDTO>> GetAllTaskItemsPaged(int pageNumber, int pageSize);
    Task<int> GetTotalTaskCountAsync();
    Task<TaskItemResponseDTO> GetTaskItemById(int id);
    Task<TaskItemResponseDTO> CreateTaskItem(TaskItemCreateRequestDTO taskItemCreateRequestDto);
    Task<TaskItemResponseDTO> UpdateTaskItemById(int id, TaskItemUpdateRequestDTO taskItemUpdateRequestDto);
    Task<TaskItemResponseDTO> DeleteTaskItemById(int id);
}
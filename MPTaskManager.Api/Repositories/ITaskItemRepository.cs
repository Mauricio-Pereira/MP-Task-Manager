using MPTaskManager.Api.Models;

namespace MPTaskManager.Api.Repositories;

public interface ITaskItemRepository
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<IEnumerable<TaskItem>> GetAllPaginatedAsync(int page, int pageSize);
    Task<int> GetTotalCountAsync();
    Task<TaskItem> GetByTaskIdAsync(int taskId);
    Task<TaskItem> PostAsync(TaskItem taskItem);
    Task<TaskItem> UpdateAsync(TaskItem taskItem);
    Task<TaskItem> DeleteAsync(int taskId);
    
}
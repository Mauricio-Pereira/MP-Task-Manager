using Microsoft.EntityFrameworkCore;
using MPTaskManager.Api.Infrastructure;
using MPTaskManager.Api.Models;

namespace MPTaskManager.Api.Repositories;

public class TaskItemRepository: ITaskItemRepository
{
    public TaskDbContext _context;
    private readonly ILogger<TaskItemRepository> _logger;
    
    public TaskItemRepository(TaskDbContext context, ILogger<TaskItemRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    public async Task<int> GetTotalCountAsync()
    {
        return await _context.TasksItems.CountAsync();
    }
    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        _logger.LogInformation("GetAllAsync called");
        return await _context.TasksItems.AsNoTracking().ToListAsync();
    }

    public async Task<IEnumerable<TaskItem>> GetAllPaginatedAsync(int page, int pageSize)
    {
        _logger.LogInformation("GetAllPaginatedAsync called");
        return await _context.TasksItems
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<TaskItem> GetByTaskIdAsync(int taskId)
    {
        _logger.LogInformation("GetByTaskIdAsync called");
        var taskItem = await _context.TasksItems.FirstOrDefaultAsync(x => x.Id == taskId);
        return taskItem;
    }

    public async Task<TaskItem> PostAsync(TaskItem taskItem)
    {
        _logger.LogInformation("PostAsync called");
        _context.TasksItems.AddAsync(taskItem);
        _context.SaveChanges();
        return taskItem;
    }

    public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
    {
        _logger.LogInformation("UpdateAsync called");
        _context.TasksItems.Update(taskItem);
        _context.SaveChanges();
        return taskItem;
        
    }

    public async Task<TaskItem> DeleteAsync(int taskId)
    {
        _logger.LogInformation("DeleteAsync called");
        var taskItem = await _context.TasksItems.FirstOrDefaultAsync(x => x.Id == taskId);
        if (taskItem == null)
        {
            _logger.LogWarning($"TaskItem with Id {taskId} not found.");
            return null;
        }
        _context.TasksItems.Remove(taskItem);
        _context.SaveChanges();
        return taskItem;
    }
}
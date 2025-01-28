using MPTaskManager.Api.Infrastructure;
using MPTaskManager.Api.Services;

namespace MPTaskManager.Api.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private ITaskItemRepository? _taskItemRepository;
    private TaskDbContext _context;
    
    public UnitOfWork(TaskDbContext context, ITaskItemRepository taskItemRepository)
    {
        _context = context;
        _taskItemRepository = taskItemRepository;
    }
    
    public ITaskItemRepository TaskItemRepository => _taskItemRepository;
    
    
    
    public async Task<bool> Commit()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
    
}
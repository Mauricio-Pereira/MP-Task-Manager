using MPTaskManager.Api.Services;

namespace MPTaskManager.Api.Repositories;

public interface IUnitOfWork
{
    ITaskItemRepository TaskItemRepository { get; }
    
    Task<bool> Commit();
    
    void Dispose();
}
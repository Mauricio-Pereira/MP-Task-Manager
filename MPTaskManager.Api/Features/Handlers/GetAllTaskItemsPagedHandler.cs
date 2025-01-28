using AutoMapper;
using MediatR;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Features.Tasks.Queries;
using MPTaskManager.Api.Repositories;
using MPTaskManager.Api.Services;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MPTaskManager.Api.Features.Handlers
{
    public class GetAllTaskItemsPagedHandler : IRequestHandler<GetAllTaskItemsPagedQuery, PagedResultDTO<TaskItemResponseDTO>>
    {
        private readonly ITaskItemService _taskItemService;
        private readonly ILogger<GetAllTaskItemsPagedHandler> _logger;

        public GetAllTaskItemsPagedHandler(ITaskItemService taskItemService, ILogger<GetAllTaskItemsPagedHandler> logger)
        {
            _taskItemService = taskItemService;
            _logger = logger;
        }

        public async Task<PagedResultDTO<TaskItemResponseDTO>> Handle(GetAllTaskItemsPagedQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Processing command GetAllTaskItemsPaged.");
            
            // Obtém os itens paginados
            var items = await _taskItemService.GetAllTaskItemsPaged(request.PageNumber, request.PageSize);
            
            // Obtém o total de tarefas
            var totalCount = await _taskItemService.GetTotalTaskCountAsync();
            
            // Cria o resultado paginado
            var pagedResult = new PagedResultDTO<TaskItemResponseDTO>
            {
                Page = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                Items = items.ToList()
            };

            _logger.LogInformation("Command GetAllTaskItemsPaged processed successfully.");
            return pagedResult;
        }
    }
}
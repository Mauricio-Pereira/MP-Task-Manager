using MediatR;
using MPTaskManager.Api.DTOs;

namespace MPTaskManager.Api.Features.Tasks.Queries
{
    public class GetAllTaskItemsPagedQuery : IRequest<PagedResultDTO<TaskItemResponseDTO>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllTaskItemsPagedQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
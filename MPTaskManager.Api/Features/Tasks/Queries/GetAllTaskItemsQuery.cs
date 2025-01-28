using MediatR;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Models;

namespace MPTaskManager.Api.Features.Tasks.Queries;

public record GetAllTaskItemsQuery : IRequest<IEnumerable<TaskItemResponseDTO>>;
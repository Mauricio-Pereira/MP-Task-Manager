using MediatR;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Models;

namespace MPTaskManager.Api.Features.Tasks.Commands;

public record UpdateTaskItemByIdCommand(int Id, TaskItemUpdateRequestDTO TaskItemUpdateRequestDto) : IRequest<TaskItemResponseDTO>;
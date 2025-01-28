using MediatR;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Api.Models;

namespace MPTaskManager.Api.Features.Tasks.Commands;

public record CreateTaskItemCommand(TaskItemCreateRequestDTO TaskItemCreateRequestDto) : IRequest<TaskItemResponseDTO>;
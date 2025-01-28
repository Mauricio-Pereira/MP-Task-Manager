using AutoMapper;
using MPTaskManager.Api.Models;

namespace MPTaskManager.Api.DTOs.Mapping;

public class MappingProfile : Profile
{

    public MappingProfile()
    {
        CreateMap<TaskItemCreateRequestDTO, TaskItem>().ReverseMap();
        CreateMap<TaskItemUpdateRequestDTO, TaskItem>().ReverseMap();
        CreateMap<TaskItemResponseDTO, TaskItem>().ReverseMap();
    }
}
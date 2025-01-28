using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace MPTaskManager.Api.DTOs;

public class TaskItemCreateRequestDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    
    public DateTime DueDate { get; set; }
}
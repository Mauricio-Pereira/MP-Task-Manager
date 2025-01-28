using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MPTaskManager.Shared.Utils;

namespace MPTaskManager.Api.DTOs;

public class TaskItemUpdateRequestDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MPTaskManager.Api.Utils;
using MPTaskManager.Shared.Utils;
using Newtonsoft.Json;

namespace MPTaskManager.Api.Models;

[Table("tasks")]
public class TaskItem
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    
    [MaxLength(500)]
    public string Description { get; set; }
    
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime CreatedDate { get; set; }
    
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }
}
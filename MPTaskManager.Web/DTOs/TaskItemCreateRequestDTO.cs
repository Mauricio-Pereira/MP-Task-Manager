
using System.ComponentModel.DataAnnotations;

namespace MPTaskManager.Api.DTOs;

public class TaskItemCreateRequestDTO
{
    [Required (ErrorMessage = "O campo 'Titulo' é obrigatório.")]
    public string Title { get; set; }
    
    [Required (ErrorMessage = "O campo 'Descrição' é obrigatório.")]
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}
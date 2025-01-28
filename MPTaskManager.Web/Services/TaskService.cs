using System.Net.Http.Json;
using System.Text.Json;
using MPTaskManager.Api.DTOs;
using MPTaskManager.Shared.Utils;
using MPTaskManager.Web.DTOs;

namespace MPTaskManager.Web.Services;

public class TaskService
{
    private readonly HttpClient _httpClient;

    // Opções personalizadas para usar o mesmo formato de data
    private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new CustomDateTimeConverter("yyyy-MM-dd HH:mm") }
    };

    public TaskService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET ALL
    public async Task<List<TaskItemResponseDTO>?> GetAllTasksAsync()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<List<TaskItemResponseDTO>>("api/task", _jsonOptions);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro ao buscar tarefas: {ex.Message}");
            return null;
        }
    }

    // GET PAGED
    public async Task<PagedResultDTO<TaskItemResponseDTO>?> GetAllTasksPagedAsync(int pageNumber, int pageSize)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/task/paged?pageNumber={pageNumber}&pageSize={pageSize}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var pagedResult = JsonSerializer.Deserialize<PagedResultDTO<TaskItemResponseDTO>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new CustomDateTimeConverter()
                }
            });
            return pagedResult;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar tarefas paginadas: {ex.Message}");
            return null;
        }
    }




    // GET BY ID
    public async Task<TaskItemResponseDTO?> GetTaskByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<TaskItemResponseDTO>($"api/task/{id}", _jsonOptions);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro ao buscar tarefa com ID {id}: {ex.Message}");
            return null;
        }
    }

    // CREATE
    public async Task CreateTaskAsync(TaskItemCreateRequestDTO model)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/task", model, _jsonOptions);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro ao criar tarefa: {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro ao criar tarefa: {ex.Message}");
        }
    }

    // UPDATE
    public async Task UpdateTaskAsync(int id, TaskItemUpdateRequestDTO model)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/task/{id}", model, _jsonOptions);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro ao atualizar tarefa: {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro ao atualizar tarefa com ID {id}: {ex.Message}");
        }
    }

    // DELETE
    public async Task DeleteTaskAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/task/{id}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Erro ao deletar tarefa com ID {id}: {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Erro ao deletar tarefa com ID {id}: {ex.Message}");
        }
    }
}

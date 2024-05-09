using Todo.Models;

namespace Todo.Contracts
{
    public interface ITodoService
    {
        Task<List<TodoForGettingDto>> GetAllTodosAsync();
        Task<TodoForGettingDto> GetSingleTodoAsync(int Id);
        Task AddTodoAsync(TodoForCreatingDto model);
        Task UpdateTodoAsync(TodoForUpdatingDto model);
        Task DeleteTodoAsync(int Id);
    }
}

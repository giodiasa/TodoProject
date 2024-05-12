using System.Linq.Expressions;
using Todo.Entities;
using Todo.Models;

namespace Todo.Contracts
{
    public interface ITodoService
    {
        Task<List<TodoForGettingDto>> GetAllTodosAsync();
        Task<List<TodoForGettingDto>> GetAllTodosAsync(Expression<Func<TodoEntity, bool>> filter);
        Task<TodoForGettingDto> GetSingleTodoAsync(int Id);
        Task AddTodoAsync(TodoForCreatingDto model);
        Task UpdateTodoAsync(TodoForUpdatingDto model);
        Task DeleteTodoAsync(int Id);
    }
}

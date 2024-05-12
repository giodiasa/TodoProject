using AutoMapper;
using System.Linq.Expressions;
using Todo.Contracts;
using Todo.Entities;
using Todo.Models;
using Todo.Service.Exceptions;

namespace Todo.Service.Implementations
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
            _mapper = MappingInitializer.Initialize();
        }
        public async Task AddTodoAsync(TodoForCreatingDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var result = _mapper.Map<TodoEntity>(model);
            await _todoRepository.AddTodoAsync(result);
            await _todoRepository.Save();
        }

        public async Task DeleteTodoAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid argument passed");
            }
            var result = await _todoRepository.GetSingleTodoAsync(x => x.Id == Id);
            if (result == null)
            {
                throw new TodoNotFoundException();
            }
            _todoRepository.DeleteTodo(result);
            await _todoRepository.Save();
        }

        public async Task<List<TodoForGettingDto>> GetAllTodosAsync()
        {
            var rawData = await _todoRepository.GetAllTodosAsync();
            if (rawData.Count == 0)
            {
                throw new TodoNotFoundException();
            }
            var result = _mapper.Map<List<TodoForGettingDto>>(rawData);
            return result;
        }
        public async Task<List<TodoForGettingDto>> GetAllTodosAsync(Expression<Func<TodoEntity, bool>> filter)
        {
            var rawData = await _todoRepository.GetAllTodosAsync(filter);
            if (rawData.Count == 0)
            {
                throw new TodoNotFoundException();
            }
            var result = _mapper.Map<List<TodoForGettingDto>>(rawData);
            return result;
        }

        public async Task<TodoForGettingDto> GetSingleTodoAsync(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid argument passed");
            }
            var rawData = await _todoRepository.GetSingleTodoAsync(x => x.Id == Id);
            if (rawData == null)
            {
                throw new TodoNotFoundException();
            }
            var result = _mapper.Map<TodoForGettingDto>(rawData);
            return result;
        }

        public async Task UpdateTodoAsync(TodoForUpdatingDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Invalid argument passed");
            }
            var result = _mapper.Map<TodoEntity>(model);
            await _todoRepository.UpdateTodoAsync(result);
            await _todoRepository.Save();
        }
    }
}

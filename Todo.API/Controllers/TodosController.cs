using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Todo.Contracts;
using Todo.Models;
using Todo.Service.Exceptions;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private ApiResponse _response;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
            _response = new();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AllTodos()
        {
            try
            {
                var isAdmin = User.IsInRole("Admin");
                if (!isAdmin)
                {
                    _response.IsSuccess = false;
                    _response.Result = null;
                    _response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    _response.Message = "user doesn't have access to view todos";
                    return StatusCode(_response.StatusCode, _response);
                }
                var result = await _todoService.GetAllTodosAsync();
                _response.Result = result;
                _response.IsSuccess = true;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                _response.Message = "Request completed successfully";
            }
            catch (TodoNotFoundException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                _response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _response.Message = ex.Message;
            }

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpGet("user/{userId}")]
        [Authorize]
        public async Task<IActionResult> AllTodosOfUser(string userId)
        {
            try
            {
                var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var isAdmin = User.IsInRole("Admin");
                if (!isAdmin && currentUserId != userId)
                {
                    _response.IsSuccess = false;
                    _response.Result = null;
                    _response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    _response.Message = "user doesn't have access to view todos";
                    return StatusCode(_response.StatusCode, _response);
                }
                var result = await _todoService.GetAllTodosAsync(x=> x.UserId == userId);
                _response.Result = result;
                _response.IsSuccess = true;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                _response.Message = "Request completed successfully";
            }
            catch (TodoNotFoundException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                _response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _response.Message = ex.Message;
            }

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpGet("user/{userId}/todo/{Id}")]
        [Authorize]
        public async Task<IActionResult> TodoOfUserById(string userId, int Id)
        {
            try
            {
                var currentUserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var isAdmin = User.IsInRole("Admin");
                if (!isAdmin && currentUserId != userId)
                {
                    _response.IsSuccess = false;
                    _response.Result = null;
                    _response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    _response.Message = "user doesn't have access to view todos";
                    return StatusCode(_response.StatusCode, _response);
                }
                var result = await _todoService.GetAllTodosAsync(x => x.UserId == userId && x.Id == Id);
                _response.Result = result;
                _response.IsSuccess = true;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                _response.Message = "Request completed successfully";
            }
            catch (TodoNotFoundException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                _response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _response.Message = ex.Message;
            }

            return StatusCode(_response.StatusCode, _response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddTodo(TodoForCreatingDto model)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var isAdmin = User.IsInRole("Admin");
                if (isAdmin)
                {
                    _response.IsSuccess = false;
                    _response.Result = null;
                    _response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    _response.Message = "admin can't create todos";
                    return StatusCode(_response.StatusCode, _response);
                }
                if (userId != model.UserId)
                {
                    _response.IsSuccess = false;
                    _response.Result = null;
                    _response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    _response.Message = "cannot add todo for another user";
                    return StatusCode(_response.StatusCode, _response);
                }
                await _todoService.AddTodoAsync(model);
                _response.Result = model;
                _response.IsSuccess = true;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.Created);
                _response.Message = "Request completed successfully";
            }
            catch (ArgumentNullException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                _response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _response.Message = ex.Message;
            }

            return StatusCode(_response.StatusCode, _response);
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteTodo(int Id)
        {
            try
            {
                var model = await _todoService.GetSingleTodoAsync(Id);
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var isAdmin = User.IsInRole("Admin");
                if (!isAdmin && userId != model.UserId)
                {
                    _response.IsSuccess = false;
                    _response.Result = null;
                    _response.StatusCode = Convert.ToInt32(HttpStatusCode.Forbidden);
                    _response.Message = "cannot delete todo of another user";
                    return StatusCode(_response.StatusCode, _response);
                }
                await _todoService.DeleteTodoAsync(Id);
                _response.Result = model;
                _response.IsSuccess = true;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.Created);
                _response.Message = "Todo deleted successfully";
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                _response.Message = ex.Message;
            }
            catch (TodoNotFoundException ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.NotFound);
                _response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = null;
                _response.StatusCode = Convert.ToInt32(HttpStatusCode.InternalServerError);
                _response.Message = ex.Message;
            }

            return StatusCode(_response.StatusCode, _response);
        }
    }
}

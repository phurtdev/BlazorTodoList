using SharedModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebClient.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetTodos();
        Task AddTodo(TodoItem newTodo);
        Task UpdateTodo(TodoItem updatedTodo);
        Task DeleteTodo(int id);
    }
}

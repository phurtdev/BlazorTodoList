using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedModels.Models;

namespace WebClient.Services
{
    public class TodoService : ITodoService
    {
        private readonly HttpClient _httpClient;

        public TodoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TodoItem>> GetTodos()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TodoItem>>("api/todo");
        }

        public async Task AddTodo(TodoItem newTodo)
        {
            await _httpClient.PostAsJsonAsync("api/todo", newTodo);
        }

        public async Task UpdateTodo(TodoItem updatedTodo)
        {
            await _httpClient.PutAsJsonAsync($"api/todo/{updatedTodo.Id}", updatedTodo);
        }

        public async Task DeleteTodo(int id)
        {
            await _httpClient.DeleteAsync($"api/todo/{id}");
        }
    }
}

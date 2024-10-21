using Microsoft.AspNetCore.Mvc;
using SharedModels.Models;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Learn Blazor", IsComplete = false },
            new TodoItem { Id = 2, Title = "Create Blazor Todo App", IsComplete = true }
        };

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetTodos()
        {
            return Ok(todos);
        }

        [HttpPost]
        public ActionResult AddTodo([FromBody] TodoItem todoItem)
        {
            todoItem.Id = todos.Count + 1;
            todos.Add(todoItem);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTodo(int id, [FromBody] TodoItem todoItem)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            todo.Title = todoItem.Title;
            todo.IsComplete = todoItem.IsComplete;
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            var todo = todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            todos.Remove(todo);
            return Ok();
        }
    }
}

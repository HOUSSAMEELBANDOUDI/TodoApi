using Microsoft.AspNetCore.Mvc;
using TodoApi.DTOs;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoServices _todoServices;

        public TodoController(ITodoServices todoServices)
        {
            _todoServices = todoServices;
        }

        // GET: api/todo
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoServices.GetAllAsync();
            return Ok(todos);
        }

        // GET: api/todo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var todo = await _todoServices.GetByIdAsync(id);
            if (todo == null)
                return NotFound();
            return Ok(todo);
        }

        // POST: api/todo
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequest request)
        {
            var todo = await _todoServices.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = todo.Id }, todo);
        }

        // PUT: api/todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTodoRequest request)
        {
            var todo = await _todoServices.UpdateAsync(id, request);
            if (todo == null)
                return NotFound();
            return Ok(todo);
        }

        // DELETE: api/todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _todoServices.DeleteAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}

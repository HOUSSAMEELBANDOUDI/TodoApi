using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly TodoDbContext _context;
        private readonly IMapper _mapper;

        public TodoServices(TodoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> CreateAsync(CreateTodoRequest request)
        {
            var todo = _mapper.Map<Todo>(request);
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo?> UpdateAsync(int id, UpdateTodoRequest request)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return null;

            _mapper.Map(request, todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return false;

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


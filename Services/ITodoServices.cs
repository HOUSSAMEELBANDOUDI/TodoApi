using TodoApi.DTOs;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface ITodoServices
    {
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(CreateTodoRequest request);
        Task<Todo?> UpdateAsync(int id, UpdateTodoRequest request);
        Task<bool> DeleteAsync(int id);
    }
}

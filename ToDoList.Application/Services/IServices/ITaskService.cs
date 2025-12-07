using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Dtos;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Services.IServices
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<TaskItem> CreateAsync(TaskCreateDto dto);
        Task<TaskItem?> UpdateAsync(Guid id, TaskUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}

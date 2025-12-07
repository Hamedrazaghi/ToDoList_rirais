using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.IRepository
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task DeleteAsync(TaskItem task);


    }
}

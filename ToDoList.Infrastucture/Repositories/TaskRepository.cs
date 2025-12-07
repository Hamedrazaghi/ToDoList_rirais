using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.IRepository;
using ToDoList.Domain.Models;
using ToDoList.Infrastucture.Context;

namespace ToDoList.Infrastucture.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TaskItem task)
        {
            await _context.TaskItems.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskItem task)
        {
            _context.TaskItems.Remove(task);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task UpdateAsync(TaskItem task)
        {
            _context.TaskItems.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}


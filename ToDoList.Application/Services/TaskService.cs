using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Application.Dtos;
using ToDoList.Application.Services.IServices;
using ToDoList.Domain.IRepository;
using ToDoList.Domain.Models;

namespace ToDoList.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }


        public async Task<TaskItem> CreateAsync(TaskCreateDto dto)
        {
            var task = new TaskItem();
            {
                task.Title = dto.Title;
                task.Description = dto.Description;
                task.DueDate = dto.DueDate;
                task.IsComplated= false;
            };
            await _repo.AddAsync(task);
            return task;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null) 
                return false;
            await _repo.DeleteAsync(task);
            return true;
            
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(Guid id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<TaskItem?> UpdateAsync(Guid id, TaskUpdateDto dto)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                return null;
            task.Title = dto.Title;
            task.Description = dto.Description;
            task.DueDate = dto.DueDate;
            task.IsComplated= false;



            await _repo.UpdateAsync(task);
            return task;

        }
    }
}

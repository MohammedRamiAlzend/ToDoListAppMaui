// Ignore Spelling: App

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Data;
using ToDoListApp.Models;
using System.Linq;
using Microsoft.VisualBasic;
using Azure.Core;


namespace ToDoListApp.Services
{
    public class TaskAppService : ITaskAppService
    {
        private readonly AppDbContext _context;
        public TaskAppService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TaskApp>> GetAllTasks()
        {
            var request = await _context.TaskApps.ToListAsync();
            return request;
        }
        // This method filters the list of items based on the id of a task. 
        public async Task<DataBaseRequest<TaskApp>> GetTaskByIdAsync(int id)
        {
            var request = await _context.TaskApps.FindAsync(id);
            return new DataBaseRequest<TaskApp>
            {
                Message = "id is done",
                Success = true,
                Data = request
            };
        }
        // This method filters the list of items based on  specified date range (startdate , and end date).
        public async Task<DataBaseRequest<List<TaskApp>>> GetTaskByDateAsync(DateTime startDate, DateTime endDate)
        {
            var request = await _context.TaskApps.Where(x => x.DueDate >= startDate && x.DueDate <= endDate).ToListAsync();
            return new DataBaseRequest<List<TaskApp>> { Success = true, Message = "Date Retrieved Successfully ", Data = request };
        }
        //This method filters the list of items based on matching the specified date.
        public async Task<DataBaseRequest<List<TaskApp>>> GetTaskByDateAsync(DateTime dueDate)
        {
            var currentTime = dueDate.ToString("yyyy-MM-dd");
            var request = await _context.TaskApps.Where(x => currentTime == x.DueDate.ToString("yyyy-MM-dd")).ToListAsync();
            return new DataBaseRequest<List<TaskApp>> { Success = true, Message = "Date Retrieved Successfully ", Data = request };
        }
        // This method filters the list of items based on current date.
        public async Task<DataBaseRequest<List<TaskApp>>> GetTaskByDateAsync()
        {
            var currentTime = DateTime.Now.ToString("yyyy-MM-dd");
            var request = await _context.TaskApps.Where(x => currentTime == x.DueDate.ToString("yyyy-MM-dd")).ToListAsync();
            return new DataBaseRequest<List<TaskApp>> { Success = true, Message = "Date Retrieved Successfully ", Data = request };
        }
        // This method filters the list of items based on the priority of a task.
        public async Task<DataBaseRequest<List<TaskApp>>> GetTasksByPriorityAsync(string priorityName)
        {
            var tasks = await _context.TaskApps.Where(x => x.Priority == priorityName).ToListAsync();
            if (tasks.Count == 0)
            {
                return new DataBaseRequest<List<TaskApp>>
                {
                    Message = $"There is no tasks with {priorityName}",
                    Success = false
                };
            }
            else
            {
                return new DataBaseRequest<List<TaskApp>> { Success = true, Message = "Data Retrieved Successfully ", Data = tasks };
            }
        }
        // This method filters the list of items based on the title of a task. 
        public async Task<DataBaseRequest<List<TaskApp>>> GetTitle(string Title)
        {
            var request = await _context.TaskApps.Where(x => x.Title.Contains(Title, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            if (request.Count == 0)
            {
                return new DataBaseRequest<List<TaskApp>>
                {
                    Message = $"There is no tasks with {Title}",
                    Success = false
                };
            }
            else
            {
                return new DataBaseRequest<List<TaskApp>> { Success = true, Message = "Data Retrieved Successfully ", Data = request };
            }
        }
        //  method of create tasks.
        public async Task<DataBaseRequest> CreateTaskAsync(TaskApp taskApp)
        {
            if (taskApp.CategoryId <= 0 || taskApp.Title == null
                || taskApp.Description == null || taskApp.Priority == null)
            {
                return new DataBaseRequest
                {
                    Message = "Sorry it cannot be created",
                    Success = false
                };
            }
            else
            {
                await _context.TaskApps.AddAsync(taskApp);
                int result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return new DataBaseRequest
                    {
                        Message = $"the task {taskApp.Title} has been created successfully",
                        Success = true
                    };
                }
                else
                {
                    return new DataBaseRequest { Message = "Sorry it cannot be created", Success = false };
                }
            }
        }
        //  method of update tasks.
        public async Task<bool> UpdateTaskAsync(TaskApp taskApp)
        {
            _context.TaskApps.Update(taskApp);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // method of delete tasks.
        public async Task<DataBaseRequest> DeleteTaskAsync(int taskId)
        {
            var taskApp = await _context.TaskApps.FindAsync(taskId);
            if (taskApp == null)
            {
                return new DataBaseRequest
                {
                    Message = "Sorry it cannot be deleted",
                    Success = false
                };
            }
            else
            {
                _context.TaskApps.Remove(taskApp);
                int result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return new DataBaseRequest
                    {
                        Message = $"the task {taskApp.TaskAppId} has been deleted successfully",
                        Success = true
                    };
                }
                else
                {
                    return new DataBaseRequest { Message = "Sorry it cannot be deleted", Success = false };
                }

            }

        }
        //  method of create category.
        public async Task <DataBaseRequest> CreateCategoryAsync(Category category)
        {
            if (category.CategoryId <= 0 || category.Name == null)
            {
                return new DataBaseRequest
                {
                    Message = "Sorry it cannot be created",
                    Success = false
                };
            }
            else
            {
                await _context.Categories.AddAsync(category);
                int result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return new DataBaseRequest
                    {
                        Message = $"the task {category.Name} has been created successfully",
                        Success = true
                    };
                }
                else
                {
                    return new DataBaseRequest { Message = "Sorry it cannot be created", Success = false };
                }
            }
        }
        // method of update category
       public async Task<DataBaseRequest> UpdateCategoryAsync(Category category)
          {
           var request = _context.Categories.Update(category);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return new DataBaseRequest
                {
                    Message = $"the task  has been updeted successfully",
                    Success = true
                };
            }
            else
            {
                return new DataBaseRequest { Message = "Sorry it cannot be updated", Success = false };
            }
        }
        // method of delete category .
        public async Task <DataBaseRequest> DeleteCategoryAsync(int CategoryId)
        {
            var request = await _context.Categories.FindAsync(CategoryId);
            if (request == null)
            {
                return new DataBaseRequest
                {
                    Message = "Sorry it cannot be deleted",
                    Success = false
                };
            }
            else
            {
                _context.Categories.Remove(request);
                int result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    return new DataBaseRequest
                    {
                        Message = $"the task {request.CategoryId} has been deleted successfully",
                        Success = true
                    };
                }
                else
                {
                    return new DataBaseRequest { Message = "Sorry it cannot be deleted", Success = false };
                }

            }
        }

    }
}


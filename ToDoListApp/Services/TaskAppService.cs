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
        public async Task<TaskApp> GetTaskByIdAsync(int id)
        {
            var request = await _context.TaskApps.FindAsync(id);
            return request;
        }
        public async Task<List<TaskApp>> GetTaskByDateAsync(DateTime startDate, DateTime endDate)
        {
            var request = await _context.TaskApps.Where(x => x.DueDate >= startDate && x.DueDate <= endDate).ToListAsync();
            return request;
        }
        public async Task<List<TaskApp>> GetTaskByDateAsync(DateTime dueDate)
        {
            var currentTime = dueDate.ToString("yyyy-MM-dd");
            var request = await _context.TaskApps.Where(x => currentTime == x.DueDate.ToString("yyyy-MM-dd")).ToListAsync();
            return request;
        }
        public async Task<List<TaskApp>> GetTaskByDateAsync()
        {
            var currentTime = DateTime.Now.ToString("yyyy-MM-dd");
            var request = await _context.TaskApps.Where(x => currentTime == x.DueDate.ToString("yyyy-MM-dd")).ToListAsync();
            return request;
        }

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


        public async Task<bool> CreateTaskAsync(TaskApp taskApp)
        {
            if (taskApp.TaskAppId <= 0 || taskApp.CategoryId <= 0 || taskApp.Title == null
                || taskApp.Description == null || taskApp.Priority == null)
            {
                return false;
            }

            else
            {
                await _context.TaskApps.AddAsync(taskApp);
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


            // we are lucky

        }
        public async Task<bool> UpdateTaskAsync(TaskApp taskApp)
        {
            _context.TaskApps.Update(taskApp);
           int result=  await _context.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteTaskAsync(int taskId)
        {
            var taskApp = await _context.TaskApps.FindAsync(taskId);
            if (taskApp == null)
            {
                return false;
            }
            else
            {
                _context.TaskApps.Remove(taskApp);
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

        }
    }


    //best team


}



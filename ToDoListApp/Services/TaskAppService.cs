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


namespace ToDoListApp.Services
{
    public class TaskAppService:ITaskAppService
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
        public async Task<DateTime> GetDateAsync(DateTime dueDate)
        {
            return await Task.FromResult(DateTime.Now);
        }
        public async Task<DateTime> GetSpecificDateAsync(DateTime dueDate)
        {
            DateTime specificDate = new DateTime(2020, 1, 1);
            return await Task.FromResult(specificDate);
        }
        public async Task<TaskApp> GetPropertyAsync(string propertyName, bool isImportant)
        {
            var tasks = await _context.TaskApps.ToListAsync();
            if (tasks == null || !tasks.Any())
            {
                return null;
            }
            if (isImportant)
            {
                tasks = tasks 
            }
            else
            {
                tasks = tasks.Where task => !task.isImportant
            }
            return 

        }


        public async Task <bool> CreateTaskAsync(TaskApp taskApp)
        {
            if (taskApp.TaskAppId <= 0 || taskApp.CategoryId <= 0  || taskApp.Title ==null 
                || taskApp.Description ==null || taskApp.Priority ==null )
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
                    return false ;
                }
               
            }


          // we are lucky

        }
        public async Task<bool> UpdateTaskAsync(TaskApp taskApp)
        {
            _context.TaskApps.Update(taskApp);
         await _context.SaveChangesAsync();
            
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
    


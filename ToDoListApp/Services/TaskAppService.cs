// Ignore Spelling: App

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Data;
using ToDoListApp.Models;

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
<<<<<<< HEAD
        public async Task createTaskAsync(TaskApp taskApp)
        {
            await _context.TaskApps.AddAsync(taskApp);
            await _context.SaveChangeAsync();
            
        }
        
            public async Task<TaskApp> UpdateTaskAsync(TaskApp taskApp)
            {
                _context.Entry(taskApp).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return taskApp;
            }
        public async Task DeleteTaskAsync(int id)
        {
            var taskApp = await _context.TaskApps.FindAsync(id);
            if (taskApp != null)
            {
                _context.TaskApps.Remove(taskApp);
                await _context.SaveChangesAsync();
            }

=======
        //ِيييييي
     
>>>>>>> 3aa424ea63927667a5c9b8224a1af019d4a17eec



        }
.

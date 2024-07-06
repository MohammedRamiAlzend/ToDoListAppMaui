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
        //ِيييييي
     

    }
}

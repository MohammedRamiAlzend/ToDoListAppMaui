// Ignore Spelling: App

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Data;

namespace ToDoListApp.Services
{
    public class TaskAppService
    {
        private readonly AppDbContext _context;
        public TaskAppService(AppDbContext context)
        {
            _context = context;
        }
    }
}

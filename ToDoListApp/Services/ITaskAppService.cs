using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public interface ITaskAppService
    {
        Task<List<TaskApp>> GetAllTasks();
        Task<TaskApp> GetTaskByIdAsync(int id);
         Task<DateTime> GetDateAsync(DateTime dueDate);
         Task<DateTime> GetSpecificDateAsync(DateTime dueDate);
        Task<TaskApp> GetPropertyAsync(string propertyName, bool isImportant);
        Task<bool> CreateTaskAsync(TaskApp taskApp);
        Task<bool> UpdateTaskAsync(TaskApp taskApp);
        Task<bool> DeleteTaskAsync(int taskId);
    }
}

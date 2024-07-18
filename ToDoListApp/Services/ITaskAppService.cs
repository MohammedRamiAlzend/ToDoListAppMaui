using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Data;
using ToDoListApp.Models;

namespace ToDoListApp.Services
{
    public interface ITaskAppService
    {
        Task<List<TaskApp>> GetAllTasks();
        Task<TaskApp> GetTaskByIdAsync(int id);
        Task<List<TaskApp>> GetTaskByDateAsync(DateTime startDate, DateTime endDate);
        Task<List<TaskApp>> GetTaskByDateAsync(DateTime dueDate);
        Task<List<TaskApp>> GetTaskByDateAsync();
        Task<DataBaseRequest<List<TaskApp>>> GetTasksByPriorityAsync(string priorityName);
        public Task<List<TaskApp>> GetTitle(string Title);
        Task<bool> UpdateTaskAsync(TaskApp taskApp);
        Task<bool> DeleteTaskAsync(int taskId);
    }
}

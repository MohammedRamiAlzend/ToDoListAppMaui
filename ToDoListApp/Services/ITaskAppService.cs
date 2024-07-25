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
        Task<DataBaseRequest<TaskApp>> GetTaskByIdAsync(int id);
        Task<DataBaseRequest<List<TaskApp>>> GetTaskByDateAsync(DateTime startDate, DateTime endDate);
        Task<DataBaseRequest<List<TaskApp>>> GetTaskByDateAsync(DateTime dueDate);
        Task<DataBaseRequest<List<TaskApp>>> GetTaskByDateAsync();
        Task<DataBaseRequest<List<TaskApp>>> GetTasksByPriorityAsync(string priorityName);
        Task<DataBaseRequest<List<TaskApp>>> GetTitle(string Title);
        Task<DataBaseRequest> CreateTaskAsync(TaskApp taskApp);
        Task<bool> UpdateTaskAsync(TaskApp taskApp);
        Task<DataBaseRequest> DeleteTaskAsync(int taskId);
        Task<DataBaseRequest> CreateCategoryAsync(Category category);
        Task<DataBaseRequest> UpdateCategoryAsync(Category category);
       Task<DataBaseRequest> DeleteCategoryAsync(int CategoryId);

    }
}

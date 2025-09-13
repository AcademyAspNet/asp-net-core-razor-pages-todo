using Razor_Pages_Todo.Models.DTOs;
using Razor_Pages_Todo.Models.Entities;

namespace Razor_Pages_Todo.Services
{
    public interface IUserTaskService
    {
        IEnumerable<UserTask> GetTasks();
        UserTask? GetTaskById(int taskId);
        UserTask CreateTask(UserTaskDto taskDto);
        bool DeleteTaskById(int taskId);
    }
}

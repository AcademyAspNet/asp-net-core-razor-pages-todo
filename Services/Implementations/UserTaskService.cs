using Razor_Pages_Todo.Models.DTOs;
using Razor_Pages_Todo.Models.Entities;

namespace Razor_Pages_Todo.Services.Implementations
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IList<UserTask> _tasks = new List<UserTask>();
        private int _nextId = 0;

        public IEnumerable<UserTask> GetTasks()
        {
            return _tasks;
        }

        public UserTask? GetTaskById(int taskId)
        {
            return _tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public UserTask CreateTask(UserTaskDto taskDto)
        {
            UserTask task = new UserTask()
            {
                Id = _nextId++,
                Title = taskDto.Title,
                Description = taskDto.Description,
                IsDone = false
            };

            _tasks.Add(task);

            return task;
        }

        public bool DeleteTaskById(int taskId)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                UserTask task = _tasks[i];

                if (task == null)
                    continue;

                if (task.Id != taskId)
                    continue;

                _tasks.RemoveAt(i);
                return true;
            }

            return false;
        }
    }
}

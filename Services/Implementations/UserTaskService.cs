using Razor_Pages_Todo.Models.DTOs;
using Razor_Pages_Todo.Models.Entities;

namespace Razor_Pages_Todo.Services.Implementations
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IList<UserTask> _tasks;
        private int _nextId;

        public UserTaskService()
        {
            _tasks = new List<UserTask>();
            _nextId = 0;

            for (int i = 0; i < 100; i++)
            {
                UserTaskDto taskDto = new UserTaskDto() { Title = $"Задача #{i}" };
                CreateTask(taskDto);
            }
        }

        public IEnumerable<UserTask> GetTasks()
        {
            return _tasks;
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
    }
}

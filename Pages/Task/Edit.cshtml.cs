using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Pages_Todo.Models.DTOs;
using Razor_Pages_Todo.Models.Entities;
using Razor_Pages_Todo.Services;

namespace Razor_Pages_Todo.Pages.Task
{
    public class EditModel : PageModel
    {
        [BindProperty(Name = "id", SupportsGet = true)]
        public int? TaskId { get; set; }

        [BindProperty]
        public UserTaskDto? UserTask { get; set; }

        private readonly IUserTaskService _userTaskService;

        public EditModel(IUserTaskService userTaskService)
        {
            _userTaskService = userTaskService;
        }

        public IActionResult OnGet()
        {
            if (TaskId == null)
                return RedirectToPage("/Index");

            UserTask? task = _userTaskService.GetTaskById((int) TaskId);

            if (task == null)
                return RedirectToPage("/Index");

            UserTask = new UserTaskDto()
            {
                Title = task.Title,
                Description = task.Description,
                IsDone = task.IsDone
            };

            return Page();
        }

        public IActionResult OnGetDelete()
        {
            if (TaskId == null)
                return RedirectToPage("/Index");

            _userTaskService.DeleteTaskById((int) TaskId);

            return RedirectToPage("/Index");
        }

        public IActionResult OnPost()
        {
            if (TaskId == null || UserTask == null)
                return RedirectToPage("/Index");

            if (!ModelState.IsValid)
                return Page();

            UserTask? task = _userTaskService.GetTaskById((int) TaskId);

            if (task == null)
                return RedirectToPage("/Index");

            task.Title = UserTask.Title;
            task.Description = UserTask.Description;
            task.IsDone = UserTask.IsDone;

            return RedirectToPage("/Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_Pages_Todo.Models.DTOs;
using Razor_Pages_Todo.Services;

namespace Razor_Pages_Todo.Pages.Task
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public UserTaskDto? UserTask { get; set; }

        public IActionResult OnPost([FromServices] IUserTaskService userTaskService)
        {
            if (UserTask == null || !ModelState.IsValid)
                return Page();

            userTaskService.CreateTask(UserTask);

            return RedirectToPage("/Index");
        }
    }
}

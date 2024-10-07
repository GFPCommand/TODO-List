using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TODO_List.Models;

namespace TODO_List.Pages
{
    public class TaskInfoModel : PageModel
    {
        ApplicationContext context;

        [BindProperty]
        public Models.Task? TaskInfo { get; set; }
        [BindProperty]
        public bool IsCompleted { get; set; }

        public TaskInfoModel(ApplicationContext db)
        {
            context = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            TaskInfo = await context.Tasks.FindAsync(id);

            if (TaskInfo == null) { return NotFound(); }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            TaskInfo.Iscompleted = IsCompleted;
            context.Tasks.Update(TaskInfo!);

            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var taskInfo = await context.Tasks.FindAsync(id);

            if (taskInfo != null)
            {
                context.Tasks.Remove(taskInfo);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }
    }
}

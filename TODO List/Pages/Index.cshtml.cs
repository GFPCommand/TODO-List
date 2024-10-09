using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TODO_List.Models;

namespace TODO_List.Pages
{
	public class IndexModel : PageModel
	{
		ApplicationContext context;
		public List<Models.Task> Tasks { get; set; } = new();

		[BindProperty]
		public Models.Task TaskInfo { get; set; } = new();

		public IndexModel(ApplicationContext db)
		{
			context = db;
		}

		public void OnGet()
		{
            Tasks = context.Tasks.AsNoTracking().OrderBy(x => x.Id).ToList();
		}

		public async Task<IActionResult> OnPost()
		{
			if (TaskInfo.Fromdate > TaskInfo.Todate) return RedirectToAction("Index");

			await context.AddAsync(TaskInfo);

			await context.SaveChangesAsync();

			return RedirectToAction("Index");
		}
    }
}

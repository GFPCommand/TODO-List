using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TODO_List.Models;

namespace TODO_List.Pages
{
    public class DownloadModel : PageModel
    {
        ApplicationContext context;

        public IActionResult OnGet()
        {
            return RedirectToPage("Index");
        }
    }
}

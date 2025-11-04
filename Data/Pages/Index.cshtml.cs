using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using TaskTracker.Data;
using TaskTracker.Models;

namespace TaskTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        public IndexModel(AppDbContext context) => _context = context;

        [BindProperty]
        public TaskItem NewTask { get; set; }
        public IQueryable<TaskItem> Tasks => _context.Tasks;

        public void OnGet(int? delete, int? toggle)
        {
            if (delete.HasValue)
            {
                var task = _context.Tasks.Find(delete.Value);
                if (task != null) { _context.Tasks.Remove(task); _context.SaveChanges(); }
            }
            if (toggle.HasValue)
            {
                var task = _context.Tasks.Find(toggle.Value);
                if (task != null) { task.IsDone = !task.IsDone; _context.SaveChanges(); }
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();
            _context.Tasks.Add(NewTask);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
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
        public TaskItem NewTask { get; set; } = new TaskItem();

        public List<TaskItem> Tasks { get; set; } = new();
        public string Filter { get; set; } = "all";
        public string? Search { get; set; }

        public int CountAll { get; set; }
        public int CountDone { get; set; }
        public int CountTodo { get; set; }

        public void OnGet(string? filter, int? delete, int? toggle, string? search)
        {
            // ações
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

            // filtros/contadores
            Filter = string.IsNullOrWhiteSpace(filter) ? "all" : filter.ToLower();
            Search = string.IsNullOrWhiteSpace(search) ? null : search.Trim();

            var query = _context.Tasks.AsQueryable();

            CountAll  = query.Count();
            CountDone = query.Count(t => t.IsDone);
            CountTodo = query.Count(t => !t.IsDone);

            if (Filter == "done")  query = query.Where(t => t.IsDone);
            if (Filter == "todo")  query = query.Where(t => !t.IsDone);
            if (!string.IsNullOrWhiteSpace(Search))
                query = query.Where(t => t.Title.Contains(Search));

            Tasks = query.OrderByDescending(t => t.Id).ToList();
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(NewTask.Title))
            {
                ModelState.AddModelError("NewTask.Title", "Informe um título");
                return Page();
            }
            _context.Tasks.Add(NewTask);
            _context.SaveChanges();
            return RedirectToPage();
        }
    }
}

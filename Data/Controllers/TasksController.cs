using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TaskTracker.Data;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TasksController(AppDbContext context) => _context = context;

        [HttpGet]
        public IActionResult GetTasks() => Ok(_context.Tasks.ToList());

        [HttpPost]
        public IActionResult AddTask([FromBody] TaskItem task)
        {
            if (string.IsNullOrWhiteSpace(task.Title)) return BadRequest("Title required");
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null) return NotFound();
            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return Ok();
        }
    }
}

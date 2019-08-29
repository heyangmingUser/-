using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using goubi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace goubi.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var todoitems= await _context.TodoItems.ToListAsync();
            if (todoitems.Count()==0)
            {
                return NotFound();
            }
            return todoitems;
        }

        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FirstOrDefaultAsync(r=>r.Id==id);

            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem item)
        {
            var todo = await _context.TodoItems.FirstOrDefaultAsync(r => r.Id == id);
            if (todo != null)
            {
                todo.Name = item.Name;
                todo.IsComplete = item.IsComplete;
                _context.Entry(todo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Ok();

        }

        [HttpPatch("{id}/{name}")]
        public async Task<IActionResult> PutPatchTodoItem(long id, string name)
        {
            var todo = await _context.TodoItems.FirstOrDefaultAsync(r => r.Id == id);
            if (todo != null)
            {
                todo.Name =name;
                _context.Entry(todo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FirstOrDefaultAsync(r=>r.Id==id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

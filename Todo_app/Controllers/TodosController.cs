using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Todo_app.Data;
using Todo_app.Models;

namespace Todo_app.Controllers
{
    public class TodosController : Controller
    {
        private readonly TodoContext _context;

        public TodosController(TodoContext context)
        {
            _context = context;
        }

        // GET: Todos
        public async Task<IActionResult> Index()
        {
              return _context.Todos != null ? 
                          View(await _context.Todos.ToListAsync()) :
                          Problem("Entity set 'TodoContext.Todos'  is null.");
        }

        // GET: Todos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Todos == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos
                .FirstOrDefaultAsync(m => m.TodoId == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: Todos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TodoId,Title,Description,IsComplete,CompletedDate")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Todos == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TodoId,Title,Description,IsComplete,CompletedDate")] Todo todo)
        {
            if (id != todo.TodoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(todo.TodoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // GET: Todos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Todos == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos
                .FirstOrDefaultAsync(m => m.TodoId == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Todos == null)
            {
                return Problem("Entity set 'TodoContext.Todos'  is null.");
            }
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoExists(int id)
        {
          return (_context.Todos?.Any(e => e.TodoId == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TODOLIST_ASP.NET_CORE_MVC.Data;
using TODOLIST_ASP.NET_CORE_MVC.Models;

namespace TODOLIST_ASP.NET_CORE_MVC.Controllers
{
    public class TodolistController : Controller
    {
        private readonly TodolistContext _context;

        public TodolistController(TodolistContext context)
        {
            _context = context;
        }

        // GET: TodolistModels
        public async Task<IActionResult> Index()
        {
              return _context.TodolistModelDB != null ? 
                          View(await _context.TodolistModelDB.ToListAsync()) :
                          Problem("Entity set 'todolistContext.TodolistModel'  is null.");
        }

        // GET: TodolistModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TodolistModelDB == null)
            {
                return NotFound();
            }

            var todolistModel = await _context.TodolistModelDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todolistModel == null)
            {
                return NotFound();
            }

            return View(todolistModel);
        }

        // GET: TodolistModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodolistModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,item")] TodolistModel todolistModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todolistModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todolistModel);
        }

        // GET: TodolistModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TodolistModelDB == null)
            {
                return NotFound();
            }

            var todolistModel = await _context.TodolistModelDB.FindAsync(id);
            if (todolistModel == null)
            {
                return NotFound();
            }
            return View(todolistModel);
        }

        // POST: TodolistModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,item")] TodolistModel todolistModel)
        {
            if (id != todolistModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todolistModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodolistModelExists(todolistModel.Id))
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
            return View(todolistModel);
        }

        // GET: TodolistModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TodolistModelDB == null)
            {
                return NotFound();
            }

            var todolistModel = await _context.TodolistModelDB
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todolistModel == null)
            {
                return NotFound();
            }

            return View(todolistModel);
        }

        // POST: TodolistModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TodolistModelDB == null)
            {
                return Problem("Entity set 'todolistContext.TodolistModel'  is null.");
            }
            var todolistModel = await _context.TodolistModelDB.FindAsync(id);
            if (todolistModel != null)
            {
                _context.TodolistModelDB.Remove(todolistModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodolistModelExists(int id)
        {
          return (_context.TodolistModelDB?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

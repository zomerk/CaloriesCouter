using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CaloriesCouter.Data;
using CaloriesCouter.Models;

namespace CaloriesCouter.Controllers
{
    public class DailyMealsController : Controller
    {
        private readonly CaloriesCouterContext _context;

        public DailyMealsController(CaloriesCouterContext context)
        {
            _context = context;
        }

        // GET: DailyMeals
        public async Task<IActionResult> Index()
        {
            var caloriesCouterContext = _context.Meals.Include(d => d.User);
            return View(await caloriesCouterContext.ToListAsync());
        }

        // GET: DailyMeals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyMeals = await _context.Meals
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyMeals == null)
            {
                return NotFound();
            }

            return View(dailyMeals);
        }

        // GET: DailyMeals/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: DailyMeals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Type,Date")] DailyMeals dailyMeals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyMeals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", dailyMeals.UserId);
            return View(dailyMeals);
        }

        // GET: DailyMeals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyMeals = await _context.Meals.FindAsync(id);
            if (dailyMeals == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", dailyMeals.UserId);
            return View(dailyMeals);
        }

        // POST: DailyMeals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Type,Date")] DailyMeals dailyMeals)
        {
            if (id != dailyMeals.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyMeals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyMealsExists(dailyMeals.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", dailyMeals.UserId);
            return View(dailyMeals);
        }

        // GET: DailyMeals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyMeals = await _context.Meals
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyMeals == null)
            {
                return NotFound();
            }

            return View(dailyMeals);
        }

        // POST: DailyMeals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyMeals = await _context.Meals.FindAsync(id);
            if (dailyMeals != null)
            {
                _context.Meals.Remove(dailyMeals);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyMealsExists(int id)
        {
            return _context.Meals.Any(e => e.Id == id);
        }
    }
}

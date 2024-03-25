using CaloriesCouter.Data;
using CaloriesCouter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace CaloriesCouter.Controllers
{
    public class UserController : Controller
    {
        private readonly CaloriesCouterContext _context;

        public IActionResult Index()
        {
            var all_users = _context.Users.ToList();
            return View(all_users);
        }

        // GET User/DailyMeals/{name}
        public List<DailyMeals> DailyMeals(string name)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name.Equals(name));
            if (user == null)
            {
                return new List<DailyMeals>(); // or throw an exception or handle it according to your application logic
            }
            else
            {
                return _context.Users.FirstOrDefault((User u) => u.Name.Equals(name))?.Meals.ToList();

            }
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Weight,KcalIntake")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}

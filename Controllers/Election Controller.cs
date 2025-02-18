using Microsoft.AspNetCore.Mvc;
using Onlinevotingsystem.Models;

namespace Onlinevotingsystem.Controllers
{
    public class ElectionController : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public ElectionController(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var elections = _context.Elections.ToList();
            return View(elections);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Election election)
        {
            if (ModelState.IsValid)
            {
                _context.Add(election);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(election);
        }
    }
}

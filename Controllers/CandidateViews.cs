using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onlinevotingsystem.Models;

namespace Onlinevotingsystem.Controllers
{
    public class CandidateViews : Controller
    {
        private readonly Data.ApplicationDbContext _context;

        public CandidateViews(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var candidates = _context.Candidates.Include(c => c.Election).ToList();
            return View(candidates);
        }

        public IActionResult Create()
        {
            ViewBag.Elections = _context.Elections.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Elections = _context.Elections.ToList();
            return View(candidate);
        }
    }
}

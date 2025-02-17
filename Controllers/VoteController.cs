using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onlinevotingsystem.Models;

namespace Onlinevotingsystem.Controllers
{
    public class VoteController : Controller
    {
        private readonly Data.ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public VoteController(Data.ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var elections = _context.Elections.Where(e => e.EndDate > DateTime.UtcNow).ToList();
            return View(elections);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(int candidateId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.HasVoted)
            {
                return RedirectToAction(nameof(Index));
            }

            var vote = new Vote
            {
                UserId = user.Id,
                CandidateId = candidateId,
                VoteDate = DateTime.UtcNow
            };

            _context.Add(vote);
            user.HasVoted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

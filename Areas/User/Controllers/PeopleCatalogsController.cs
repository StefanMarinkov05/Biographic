using Biographic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Biographic.Areas.User.Controllers
{
    [Area("User")]
    public class PeopleCatalogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PeopleCatalogsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int? personId)
        {
            var user = await _userManager.GetUserAsync(User);
            var catalogs = await _context.UsersCatalogs
                .Include(uc => uc.PeopleCatalogs)
                    .ThenInclude(pc => pc.People)
                .Where(uc => uc.UserId == user.Id)
                .SelectMany(uc => uc.PeopleCatalogs)
                .ToListAsync();

            if (personId != null)
            {
                var person = await _context.People.FindAsync(personId);
                if (person != null)
                {
                    ViewBag.PersonName = person.Name;
                }
            }

            return View(catalogs);
        }


        [HttpPost]
        public async Task<IActionResult> CreateEmptyCatalog(string name)
        {
            var user = await _userManager.GetUserAsync(User);

            var userCatalogGroup = await _context.UsersCatalogs
                .Include(uc => uc.PeopleCatalogs)
                .FirstOrDefaultAsync(uc => uc.UserId == user.Id);

            if (userCatalogGroup == null)
            {
                userCatalogGroup = new UserCatalogs
                {
                    UserId = user.Id,
                    ApplicationUser = user
                };
                _context.UsersCatalogs.Add(userCatalogGroup);
                await _context.SaveChangesAsync();
            }

            var catalog = new PeopleCatalog
            {
                Name = name,
                UserId = user.Id,
                ApplicationUser = user
            };

            userCatalogGroup.PeopleCatalogs.Add(catalog);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalogWithPerson(string name, int personId)
        {
            var user = await _userManager.GetUserAsync(User);
            var person = await _context.People.FindAsync(personId);
            if (person == null) return NotFound();

            var userCatalogGroup = await _context.UsersCatalogs
                .Include(uc => uc.PeopleCatalogs)
                .FirstOrDefaultAsync(uc => uc.UserId == user.Id);

            if (userCatalogGroup == null)
            {
                userCatalogGroup = new UserCatalogs
                {
                    UserId = user.Id,
                    ApplicationUser = user
                };
                _context.UsersCatalogs.Add(userCatalogGroup);
                await _context.SaveChangesAsync();
            }

            var catalog = new PeopleCatalog
            {
                Name = name,
                UserId = user.Id,
                ApplicationUser = user
            };
            catalog.People.Add(person);

            userCatalogGroup.PeopleCatalogs.Add(catalog);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { personId });
        }

        [HttpPost]
        public async Task<IActionResult> RemovePersonFromCatalog(int catalogId, int personId)
        {
            var catalog = await _context.PeopleCatalogs
                .Include(c => c.People)
                .FirstOrDefaultAsync(c => c.Id == catalogId);

            var person = await _context.People.FindAsync(personId);

            if (catalog != null && person != null)
            {
                catalog.People.Remove(person);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", new { personId });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCatalog(int id)
        {
            var catalog = await _context.PeopleCatalogs
                .Include(c => c.People)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (catalog != null)
            {
                _context.PeopleCatalogs.Remove(catalog);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditCatalog(int id, string newName)
        {
            var catalog = await _context.PeopleCatalogs.FindAsync(id);
            if (catalog != null && !string.IsNullOrWhiteSpace(newName))
            {
                catalog.Name = newName.Trim();
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPersonToCatalog(int catalogId, int personId)
        {
            var catalog = await _context.PeopleCatalogs
                .Include(c => c.People)
                .FirstOrDefaultAsync(c => c.Id == catalogId);

            if (catalog == null)
            {
                return NotFound();
            }

            var person = await _context.People.FindAsync(personId);
            if (person == null)
            {
                return NotFound();
            }

            // Avoid adding duplicates
            if (!catalog.People.Any(p => p.Id == personId))
            {
                catalog.People.Add(person);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index), new { personId });
        }

    }
}

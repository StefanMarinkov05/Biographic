using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biographic;
using Biographic.Models;

namespace Biographic.Areas.Admin.Controllers
{
    [Authorize(Roles = AddUsersInDB.ADMIN_ROLE)]
    [Area("Admin")]
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PeopleController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Admin/People
        public async Task<IActionResult> Index()
        {
            var people = _context.People.Include(p => p.Country).Include(p => p.Profession);
            return View(await people.ToListAsync());
        }

        // GET: Admin/People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var person = await _context.People
                .Include(p => p.Country)
                .Include(p => p.Profession)
                .FirstOrDefaultAsync(m => m.Id == id);

            return person == null ? NotFound() : View(person);
        }

        // GET: Admin/People/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            ViewData["ProfessionId"] = new SelectList(_context.Professions, "Id", "Name");
            return View();
        }

        // POST: Admin/People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person, IFormFile imageFile)
        {
            TryValidateModel(person);

            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();

                if (imageFile != null && imageFile.Length > 0)
                {

                    string filePath = Path.Combine("wwwroot/pictures", $"person{person.Id}.jpg");

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(fileStream);
                    }

                    person.ProfileImage = $"person{person.Id}.jpg";
                    _context.Update(person); 
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", person.CountryId);
            ViewData["ProfessionId"] = new SelectList(_context.Professions, "Id", "Name", person.ProfessionId);
            return View(person);
        }


        // GET: Admin/People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var person = await _context.People.FindAsync(id);
            if (person == null) return NotFound();

            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", person.CountryId);
            ViewData["ProfessionId"] = new SelectList(_context.Professions, "Id", "Name", person.ProfessionId);
            return View(person);
        }

        // POST: Admin/People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ProfileImage,CountryId,ProfessionId,Biography,StartDate,IsDead,EndDate,ProfileImageFile")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (person.ProfileImageFile != null)
                    {
                        if (!string.IsNullOrEmpty(person.ProfileImage))
                        {
                            string oldImagePath = Path.Combine(_environment.WebRootPath, "pictures", person.ProfileImage);
                            if (System.IO.File.Exists(oldImagePath))
                            {
                                System.IO.File.Delete(oldImagePath);
                            }
                        }

                        // Save the new image
                        string filePath = Path.Combine(_environment.WebRootPath, "pictures", $"person{person.Id}.jpg");

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await person.ProfileImageFile.CopyToAsync(fileStream);
                        }

                        person.ProfileImage = $"person{person.Id}.jpg";
                    }

                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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

            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", person.CountryId);
            ViewData["ProfessionId"] = new SelectList(_context.Professions, "Id", "Name", person.ProfessionId);
            return View(person);
        }


        // GET: Admin/People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var person = await _context.People
                .Include(p => p.Country)
                .Include(p => p.Profession)
                .FirstOrDefaultAsync(m => m.Id == id);

            return person == null ? NotFound() : View(person);
        }

        // POST: Admin/People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                string imagePath = Path.Combine(_environment.WebRootPath, "pictures", $"person{id}.jpg");
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool PersonExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}

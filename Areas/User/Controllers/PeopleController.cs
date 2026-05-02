using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biographic;
using Biographic.Models;

namespace Biographic.Areas.User.Controllers
{
    [Area("User")]
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/People
        public async Task<IActionResult> Index(string sortOrder)
        {
            var peopleQuery = _context.People
                .Include(p => p.Country) 
                .Include(p => p.Profession) 
                .AsQueryable();

            ViewData["IdSortParm"] = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewData["NameSortParm"] = sortOrder == "name_asc" ? "name_desc" : "name_asc";
            ViewData["CountrySortParm"] = sortOrder == "country_asc" ? "country_desc" : "country_asc";
            ViewData["ProfessionSortParm"] = sortOrder == "profession_asc" ? "profession_desc" : "profession_asc";
            ViewData["BirthYearSortParm"] = sortOrder == "birthyear_asc" ? "birthyear_desc" : "birthyear_asc";

            switch (sortOrder)
            {
                case "id_desc":
                    peopleQuery = peopleQuery.OrderByDescending(p => p.Id);
                    break;
                case "name_asc":
                    peopleQuery = peopleQuery.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    peopleQuery = peopleQuery.OrderByDescending(p => p.Name);
                    break;
                case "country_asc":
                    peopleQuery = peopleQuery.OrderBy(p => p.Country.Name);
                    break;
                case "country_desc":
                    peopleQuery = peopleQuery.OrderByDescending(p => p.Country.Name);
                    break;
                case "profession_asc":
                    peopleQuery = peopleQuery.OrderBy(p => p.Profession.Name);
                    break;
                case "profession_desc":
                    peopleQuery = peopleQuery.OrderByDescending(p => p.Profession.Name);
                    break;
                case "birthyear_asc":
                    peopleQuery = peopleQuery.OrderBy(p => p.StartDate);
                    break;
                case "birthyear_desc":
                    peopleQuery = peopleQuery.OrderByDescending(p => p.StartDate);
                    break;
                default:
                    peopleQuery = peopleQuery.OrderBy(p => p.Id);
                    break;
            }

            var peopleList = await peopleQuery.ToListAsync();
            ViewData["People"] = peopleList; 

            return View(peopleList);
        }

        // GET: User/People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.People
                .Include(p => p.Country)
                .Include(p => p.Profession)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
    }
}

#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonDatabase.Data;
using PersonDatabase.Models;

namespace PersonDatabase.Controllers
{

    public class PeopleController : Controller
    {
        private readonly PersonDatabaseContext _context;

        public PeopleController(PersonDatabaseContext context)
        {
            _context = context;
        }

            // GET: People
            public async Task<IActionResult> Index(string job, string town, string searchString)
        {
        
            IQueryable<string> JobQuery = from m in _context.Person
                                            orderby m.Job
                                            select m.Job;

            IQueryable<string> TownQuery = from m in _context.Person
                                          orderby m.Town
                                          select m.Town;

            var people = from m in _context.Person
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                people = people.Where(s => s.Name!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(job))
            {
                people = people.Where(x => x.Job == job);
            }

            if (!string.IsNullOrEmpty(town))
            {
                people = people.Where(x => x.Town == town);
            }

            var VM = new CityJobViewModel
            {
                Jobs = new SelectList(await JobQuery.Distinct().ToListAsync()),
                Towns = new SelectList(await TownQuery.Distinct().ToListAsync()),
                People = await people.ToListAsync()
            };

                
        

            return View(VM);
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDate,Age,Job,PhoneNumber,Adress")] Person person)
        {
            person.Age = DateTime.Now.Year - person.BirthDate.Year;
            if (DateTime.Now.DayOfYear < person.BirthDate.DayOfYear)
                person.Age = person.Age - 1;

            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDate,Age,Job,PhoneNumber,Adress")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}

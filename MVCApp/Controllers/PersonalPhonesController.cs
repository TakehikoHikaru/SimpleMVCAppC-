using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApp.Data;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class PersonalPhonesController : Controller
    {
        private readonly MVCAppContext _context;

        public PersonalPhonesController(MVCAppContext context)
        {
            _context = context;
        }

        // GET: PersonalPhones
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalPhone.ToListAsync());
        }

        // GET: PersonalPhones/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalPhone = await _context.PersonalPhone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalPhone == null)
            {
                return NotFound();
            }

            return View(personalPhone);
        }

        // GET: PersonalPhones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalPhones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DDD,DDI,Number")] PersonalPhone personalPhone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalPhone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalPhone);
        }

        // GET: PersonalPhones/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalPhone = await _context.PersonalPhone.FindAsync(id);
            if (personalPhone == null)
            {
                return NotFound();
            }
            return View(personalPhone);
        }

        // POST: PersonalPhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,DDD,DDI,Number")] PersonalPhone personalPhone)
        {
            if (id != personalPhone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalPhoneExists(personalPhone.Id))
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
            return View(personalPhone);
        }

        // GET: PersonalPhones/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalPhone = await _context.PersonalPhone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalPhone == null)
            {
                return NotFound();
            }

            return View(personalPhone);
        }

        // POST: PersonalPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var personalPhone = await _context.PersonalPhone.FindAsync(id);
            _context.PersonalPhone.Remove(personalPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalPhoneExists(string id)
        {
            return _context.PersonalPhone.Any(e => e.Id == id);
        }
    }
}

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
    public class CommercialPhonesController : Controller
    {
        private readonly MVCAppContext _context;

        public CommercialPhonesController(MVCAppContext context)
        {
            _context = context;
        }

        // GET: CommercialPhones
        public async Task<IActionResult> Index()
        {
            return View(await _context.CommercialPhone.ToListAsync());
        }

        // GET: CommercialPhones/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialPhone = await _context.CommercialPhone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commercialPhone == null)
            {
                return NotFound();
            }

            return View(commercialPhone);
        }

        // GET: CommercialPhones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommercialPhones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DDD,DDI,Number")] CommercialPhone commercialPhone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commercialPhone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commercialPhone);
        }

        // GET: CommercialPhones/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialPhone = await _context.CommercialPhone.FindAsync(id);
            if (commercialPhone == null)
            {
                return NotFound();
            }
            return View(commercialPhone);
        }

        // POST: CommercialPhones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,DDD,DDI,Number")] CommercialPhone commercialPhone)
        {
            if (id != commercialPhone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commercialPhone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommercialPhoneExists(commercialPhone.Id))
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
            return View(commercialPhone);
        }

        // GET: CommercialPhones/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commercialPhone = await _context.CommercialPhone
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commercialPhone == null)
            {
                return NotFound();
            }

            return View(commercialPhone);
        }

        // POST: CommercialPhones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var commercialPhone = await _context.CommercialPhone.FindAsync(id);
            _context.CommercialPhone.Remove(commercialPhone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommercialPhoneExists(string id)
        {
            return _context.CommercialPhone.Any(e => e.Id == id);
        }
    }
}

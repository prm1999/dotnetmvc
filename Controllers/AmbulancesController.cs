using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital_Management_System.Models;

namespace Hospital.Controllers
{
    public class AmbulancesController : Controller
    {
        private readonly HospitalContext _context;

        public AmbulancesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Ambulances
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.Ambulance.Include(a => a.AmbulanceDriver);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: Ambulances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambulance = await _context.Ambulance
                .Include(a => a.AmbulanceDriver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ambulance == null)
            {
                return NotFound();
            }

            return View(ambulance);
        }

        // GET: Ambulances/Create
        public IActionResult Create()
        {
            ViewData["AmbulanceDriverId"] = new SelectList(_context.AmbulanceDriver, "Id", "Address");
            return View();
        }

        // POST: Ambulances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AmbulanceId,AmbulanceStatus,AmbulanceDriverId")] Ambulance ambulance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ambulance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AmbulanceDriverId"] = new SelectList(_context.AmbulanceDriver, "Id", "Address", ambulance.AmbulanceDriverId);
            return View(ambulance);
        }

        // GET: Ambulances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambulance = await _context.Ambulance.FindAsync(id);
            if (ambulance == null)
            {
                return NotFound();
            }
            ViewData["AmbulanceDriverId"] = new SelectList(_context.AmbulanceDriver, "Id", "Address", ambulance.AmbulanceDriverId);
            return View(ambulance);
        }

        // POST: Ambulances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AmbulanceId,AmbulanceStatus,AmbulanceDriverId")] Ambulance ambulance)
        {
            if (id != ambulance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ambulance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmbulanceExists(ambulance.Id))
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
            ViewData["AmbulanceDriverId"] = new SelectList(_context.AmbulanceDriver, "Id", "Address", ambulance.AmbulanceDriverId);
            return View(ambulance);
        }

        // GET: Ambulances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambulance = await _context.Ambulance
                .Include(a => a.AmbulanceDriver)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ambulance == null)
            {
                return NotFound();
            }

            return View(ambulance);
        }

        // POST: Ambulances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ambulance = await _context.Ambulance.FindAsync(id);
            _context.Ambulance.Remove(ambulance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmbulanceExists(int id)
        {
            return _context.Ambulance.Any(e => e.Id == id);
        }
    }
}

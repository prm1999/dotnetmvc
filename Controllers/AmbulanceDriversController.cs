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
    public class AmbulanceDriversController : Controller
    {
        private readonly HospitalContext _context;

        public AmbulanceDriversController(HospitalContext context)
        {
            _context = context;
        }

        // GET: AmbulanceDrivers
        public async Task<IActionResult> Index()
        {
            return View(await _context.AmbulanceDriver.ToListAsync());
        }

        // GET: AmbulanceDrivers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambulanceDriver = await _context.AmbulanceDriver
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ambulanceDriver == null)
            {
                return NotFound();
            }

            return View(ambulanceDriver);
        }

        // GET: AmbulanceDrivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AmbulanceDrivers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Contact,Address,Cnic")] AmbulanceDriver ambulanceDriver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ambulanceDriver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ambulanceDriver);
        }

        // GET: AmbulanceDrivers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambulanceDriver = await _context.AmbulanceDriver.FindAsync(id);
            if (ambulanceDriver == null)
            {
                return NotFound();
            }
            return View(ambulanceDriver);
        }

        // POST: AmbulanceDrivers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Contact,Address,Cnic")] AmbulanceDriver ambulanceDriver)
        {
            if (id != ambulanceDriver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ambulanceDriver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmbulanceDriverExists(ambulanceDriver.Id))
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
            return View(ambulanceDriver);
        }

        // GET: AmbulanceDrivers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ambulanceDriver = await _context.AmbulanceDriver
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ambulanceDriver == null)
            {
                return NotFound();
            }

            return View(ambulanceDriver);
        }

        // POST: AmbulanceDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ambulanceDriver = await _context.AmbulanceDriver.FindAsync(id);
            _context.AmbulanceDriver.Remove(ambulanceDriver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmbulanceDriverExists(int id)
        {
            return _context.AmbulanceDriver.Any(e => e.Id == id);
        }
    }
}

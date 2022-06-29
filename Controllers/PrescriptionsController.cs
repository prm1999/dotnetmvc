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
    public class PrescriptionsController : Controller
    {
        private readonly HospitalContext _context;

        public PrescriptionsController(HospitalContext context)
        {
            _context = context;
        }

        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.Prescription.Include(p => p.Doctor).Include(p => p.Patient);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // GET: Prescriptions/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "BloodGroup");
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FirstName");
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DoctorId,DoctorName,DoctorSpecialization,PatientId,UserName,PatientName,PatientGender,PatientAge,MedicalTest1,MedicalTest2,MedicalTest3,MedicalTest4,Medicine1,Morning1,Afternoon1,Evening1,Medicine2,Morning2,Afternoon2,Evening2,Morning3,Afternoon3,Evening3,Morning4,Afternoon4,Evening4,Morning5,Afternoon5,Evening5,Morning6,Afternoon6,Evening6,Medicine7,Morning7,Afternoon7,Evening7,CheckUpAfterDays,PrescriptionAddDate,DoctorTiming")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "BloodGroup", prescription.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FirstName", prescription.PatientId);
            return View(prescription);
        }

        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "BloodGroup", prescription.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FirstName", prescription.PatientId);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DoctorId,DoctorName,DoctorSpecialization,PatientId,UserName,PatientName,PatientGender,PatientAge,MedicalTest1,MedicalTest2,MedicalTest3,MedicalTest4,Medicine1,Morning1,Afternoon1,Evening1,Medicine2,Morning2,Afternoon2,Evening2,Morning3,Afternoon3,Evening3,Morning4,Afternoon4,Evening4,Morning5,Afternoon5,Evening5,Morning6,Afternoon6,Evening6,Medicine7,Morning7,Afternoon7,Evening7,CheckUpAfterDays,PrescriptionAddDate,DoctorTiming")] Prescription prescription)
        {
            if (id != prescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "Id", "BloodGroup", prescription.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "FirstName", prescription.PatientId);
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescription
                .Include(p => p.Doctor)
                .Include(p => p.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prescription = await _context.Prescription.FindAsync(id);
            _context.Prescription.Remove(prescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
            return _context.Prescription.Any(e => e.Id == id);
        }
    }
}

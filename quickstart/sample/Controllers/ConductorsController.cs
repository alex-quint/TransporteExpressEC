using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleMvcApp.Data;
using SampleMvcApp.ViewModels;

namespace SampleMvcApp.Controllers
{
    public class ConductorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConductorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Conductors
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Conductor.ToListAsync());
        }

        // GET: Conductors/Details/5
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conductor == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductor
                .FirstOrDefaultAsync(m => m.IdConductor == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // GET: Conductors/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Conductors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("IdConductor,Cedula,NumeroTelefono,FechaNacimiento,FechaEmisionLicencia,FechaVencimientoLicencia")] Conductor conductor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conductor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(conductor);
        }

        // GET: Conductors/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conductor == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductor.FindAsync(id);
            if (conductor == null)
            {
                return NotFound();
            }
            return View(conductor);
        }

        // POST: Conductors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("IdConductor,Cedula,NumeroTelefono,FechaNacimiento,FechaEmisionLicencia,FechaVencimientoLicencia")] Conductor conductor)
        {
            if (id != conductor.IdConductor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conductor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConductorExists(conductor.IdConductor))
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
            return View(conductor);
        }

        // GET: Conductors/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conductor == null)
            {
                return NotFound();
            }

            var conductor = await _context.Conductor
                .FirstOrDefaultAsync(m => m.IdConductor == id);
            if (conductor == null)
            {
                return NotFound();
            }

            return View(conductor);
        }

        // POST: Conductors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conductor == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Conductor'  is null.");
            }
            var conductor = await _context.Conductor.FindAsync(id);
            if (conductor != null)
            {
                _context.Conductor.Remove(conductor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConductorExists(int id)
        {
          return _context.Conductor.Any(e => e.IdConductor == id);
        }
    }
}

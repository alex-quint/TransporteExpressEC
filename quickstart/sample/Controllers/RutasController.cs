using System;
using System.Collections.Generic;
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
    public class RutasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RutasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rutas
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.Ruta.ToListAsync());
        }

        // GET: Rutas/Details/5
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ruta == null)
            {
                return NotFound();
            }

            var ruta = await _context.Ruta
                .FirstOrDefaultAsync(m => m.IdRuta == id);
            if (ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

        // GET: Rutas/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rutas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Create([Bind("IdRuta,FechaEmisionLicencia,FechaVencimientoLicencia,PuntoLlegada,Precio")] Ruta ruta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ruta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ruta);
        }

        // GET: Rutas/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ruta == null)
            {
                return NotFound();
            }

            var ruta = await _context.Ruta.FindAsync(id);
            if (ruta == null)
            {
                return NotFound();
            }
            return View(ruta);
        }

        // POST: Rutas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int id, [Bind("IdRuta,FechaEmisionLicencia,FechaVencimientoLicencia,PuntoLlegada,Precio")] Ruta ruta)
        {
            if (id != ruta.IdRuta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ruta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RutaExists(ruta.IdRuta))
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
            return View(ruta);
        }

        // GET: Rutas/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ruta == null)
            {
                return NotFound();
            }

            var ruta = await _context.Ruta
                .FirstOrDefaultAsync(m => m.IdRuta == id);
            if (ruta == null)
            {
                return NotFound();
            }

            return View(ruta);
        }

        // POST: Rutas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ruta == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ruta'  is null.");
            }
            var ruta = await _context.Ruta.FindAsync(id);
            if (ruta != null)
            {
                _context.Ruta.Remove(ruta);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RutaExists(int id)
        {
          return _context.Ruta.Any(e => e.IdRuta == id);
        }
    }
}

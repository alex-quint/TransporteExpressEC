using SampleMvcApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace SampleMvcApp.Controllers
{
    public class ViajesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ViajesController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            webHostEnvironment = webHost;
        }

        /*[Authorize(Policy = "AdminPolicy")]
        [Authorize(Policy = "UserPolicy")]*/
        public IActionResult Index()
        {
            List<Viaje> viajes = _context.Viaje.ToList();
            return View(viajes);
        }

        [HttpGet]
        /*[Authorize(Policy = "AdminPolicy")]*/
        public IActionResult Create()
        {
            Viaje viaje = new Viaje();
            return View(viaje);
        }

        [HttpPost]
        /*[Authorize(Policy = "AdminPolicy")]*/
        public ActionResult Create(Viaje viaje)
        {
            string uniqueFileName = UploadedFile(viaje);
            viaje.ImagenUrl = uniqueFileName;
            _context.Attach(viaje);
            _context.Entry(viaje).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private string UploadedFile(Viaje viaje)
        {
            string uniqueFileName = null;

            if (viaje.ImagenLugar != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + viaje.ImagenLugar.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    viaje.ImagenLugar.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}

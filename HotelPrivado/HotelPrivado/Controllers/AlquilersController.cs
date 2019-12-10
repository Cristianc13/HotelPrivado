using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelPrivado.Data;
using HotelPrivado.Models;

namespace HotelPrivado.Controllers
{
    public class AlquilersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlquilersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alquilers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alquiler.Include(a => a.Cliente).Include(a => a.Habitacion).Include(a => a.Vendedor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alquilers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler
                .Include(a => a.Cliente)
                .Include(a => a.Habitacion)
                .Include(a => a.Vendedor)
                .FirstOrDefaultAsync(m => m.idAlquiler == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // GET: Alquilers/Create
        public IActionResult Create()
        {
            ViewData["idCliente"] = new SelectList(_context.Set<Cliente>(), "idCliente", "idCliente");
            ViewData["idHabitacion"] = new SelectList(_context.Set<Habitacion>(), "idHabitacion", "idHabitacion");
            ViewData["idVendedor"] = new SelectList(_context.Set<Vendedor>(), "idVendedor", "idVendedor");
            return View();
        }

        // POST: Alquilers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idAlquiler,Precio,FechaEnt,FechaSal,Observacion,idVendedor,idCliente,idHabitacion")] Alquiler alquiler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alquiler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idCliente"] = new SelectList(_context.Set<Cliente>(), "idCliente", "idCliente", alquiler.idCliente);
            ViewData["idHabitacion"] = new SelectList(_context.Set<Habitacion>(), "idHabitacion", "idHabitacion", alquiler.idHabitacion);
            ViewData["idVendedor"] = new SelectList(_context.Set<Vendedor>(), "idVendedor", "idVendedor", alquiler.idVendedor);
            return View(alquiler);
        }

        // GET: Alquilers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }
            ViewData["idCliente"] = new SelectList(_context.Set<Cliente>(), "idCliente", "idCliente", alquiler.idCliente);
            ViewData["idHabitacion"] = new SelectList(_context.Set<Habitacion>(), "idHabitacion", "idHabitacion", alquiler.idHabitacion);
            ViewData["idVendedor"] = new SelectList(_context.Set<Vendedor>(), "idVendedor", "idVendedor", alquiler.idVendedor);
            return View(alquiler);
        }

        // POST: Alquilers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idAlquiler,Precio,FechaEnt,FechaSal,Observacion,idVendedor,idCliente,idHabitacion")] Alquiler alquiler)
        {
            if (id != alquiler.idAlquiler)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alquiler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlquilerExists(alquiler.idAlquiler))
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
            ViewData["idCliente"] = new SelectList(_context.Set<Cliente>(), "idCliente", "idCliente", alquiler.idCliente);
            ViewData["idHabitacion"] = new SelectList(_context.Set<Habitacion>(), "idHabitacion", "idHabitacion", alquiler.idHabitacion);
            ViewData["idVendedor"] = new SelectList(_context.Set<Vendedor>(), "idVendedor", "idVendedor", alquiler.idVendedor);
            return View(alquiler);
        }

        // GET: Alquilers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alquiler = await _context.Alquiler
                .Include(a => a.Cliente)
                .Include(a => a.Habitacion)
                .Include(a => a.Vendedor)
                .FirstOrDefaultAsync(m => m.idAlquiler == id);
            if (alquiler == null)
            {
                return NotFound();
            }

            return View(alquiler);
        }

        // POST: Alquilers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alquiler = await _context.Alquiler.FindAsync(id);
            _context.Alquiler.Remove(alquiler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlquilerExists(int id)
        {
            return _context.Alquiler.Any(e => e.idAlquiler == id);
        }
    }
}

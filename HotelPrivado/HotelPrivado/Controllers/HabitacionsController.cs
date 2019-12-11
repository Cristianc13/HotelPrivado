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
    public class HabitacionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabitacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Habitacions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Habitacion.Include(h => h.Tipo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Habitacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion
                .Include(h => h.Tipo)
                .FirstOrDefaultAsync(m => m.idHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // GET: Habitacions/Create
        public IActionResult Create()
        {
            ViewData["idTipo"] = new SelectList(_context.Tipo, "idTipo", "Nombre");
            return View();
        }

        // POST: Habitacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idHabitacion,NumeroCamas,Descripcion,Precio,Observacion,idTipo")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["idTipo"] = new SelectList(_context.Tipo, "idTipo", "idTipo", habitacion.idTipo);
            return View(habitacion);
        }

        // GET: Habitacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            ViewData["idTipo"] = new SelectList(_context.Tipo, "idTipo", "Nombre", habitacion.idTipo);
            return View(habitacion);
        }

        // POST: Habitacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idHabitacion,NumeroCamas,Descripcion,Precio,Observacion,idTipo")] Habitacion habitacion)
        {
            if (id != habitacion.idHabitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.idHabitacion))
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
            ViewData["idTipo"] = new SelectList(_context.Tipo, "idTipo", "idTipo", habitacion.idTipo);
            return View(habitacion);
        }

        // GET: Habitacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitacion
                .Include(h => h.Tipo)
                .FirstOrDefaultAsync(m => m.idHabitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: Habitacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habitacion = await _context.Habitacion.FindAsync(id);
            _context.Habitacion.Remove(habitacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionExists(int id)
        {
            return _context.Habitacion.Any(e => e.idHabitacion == id);
        }
    }
}

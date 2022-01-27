using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Colegio.Models;

namespace Colegio.Controllers
{
    public class EstudianteMateriasController : Controller
    {
        private readonly ControlEscolarContext _context;

        public EstudianteMateriasController(ControlEscolarContext context)
        {
            _context = context;
        }

        // GET: EstudianteMaterias
        public async Task<IActionResult> Index()
        {
            var controlEscolarContext = _context.EstudianteMateria.Include(e => e.IdEstudianteNavigation).Include(e => e.IdMateriaNavigation);
            return View(await controlEscolarContext.ToListAsync());
        }

        // GET: EstudianteMaterias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteMateria = await _context.EstudianteMateria
                .Include(e => e.IdEstudianteNavigation)
                .Include(e => e.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (estudianteMateria == null)
            {
                return NotFound();
            }

            return View(estudianteMateria);
        }

        // GET: EstudianteMaterias/Create
        public IActionResult Create()
        {
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "IdEtudiante", "Nombre");
            ViewData["IdMateria"] = new SelectList(_context.Materia, "IdMateria", "Nombre");
            return View();
        }

        // POST: EstudianteMaterias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstudiante,IdMateria")] EstudianteMateria estudianteMateria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudianteMateria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "IdEtudiante", "Nombre", estudianteMateria.IdEstudiante);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "IdMateria", "Nombre", estudianteMateria.IdMateria);
            return View(estudianteMateria);
        }

        // GET: EstudianteMaterias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteMateria = await _context.EstudianteMateria.FindAsync(id);
            if (estudianteMateria == null)
            {
                return NotFound();
            }
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "IdEtudiante", "Nombre", estudianteMateria.IdEstudiante);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "IdMateria", "Nombre", estudianteMateria.IdMateria);
            return View(estudianteMateria);
        }

        // POST: EstudianteMaterias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstudiante,IdMateria")] EstudianteMateria estudianteMateria)
        {
            if (id != estudianteMateria.IdEstudiante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudianteMateria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteMateriaExists(estudianteMateria.IdEstudiante))
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
            ViewData["IdEstudiante"] = new SelectList(_context.Estudiante, "IdEtudiante", "Nombre", estudianteMateria.IdEstudiante);
            ViewData["IdMateria"] = new SelectList(_context.Materia, "IdMateria", "Nombre", estudianteMateria.IdMateria);
            return View(estudianteMateria);
        }

        // GET: EstudianteMaterias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudianteMateria = await _context.EstudianteMateria
                .Include(e => e.IdEstudianteNavigation)
                .Include(e => e.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.IdEstudiante == id);
            if (estudianteMateria == null)
            {
                return NotFound();
            }

            return View(estudianteMateria);
        }

        // POST: EstudianteMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudianteMateria = await _context.EstudianteMateria.FindAsync(id);
            _context.EstudianteMateria.Remove(estudianteMateria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteMateriaExists(int id)
        {
            return _context.EstudianteMateria.Any(e => e.IdEstudiante == id);
        }
    }
}

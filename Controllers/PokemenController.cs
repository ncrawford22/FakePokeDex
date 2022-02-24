using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pokedex.Models;
using Pokemon.Data;

namespace Pokedex.Controllers
{
    public class PokemenController : Controller
    {
        private readonly PokeWorldContext _context;

        public PokemenController(PokeWorldContext context)
        {
            _context = context;
        }

        // GET: Pokemen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pokemons.ToListAsync());
        }

        // GET: Pokemen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemons = await _context.Pokemons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemons == null)
            {
                return NotFound();
            }

            return View(pokemons);
        }

        // GET: Pokemen/Create
        public IActionResult Create()
        {
            List<Pokemons> elementList = _context.Pokemons.ToList();
            ViewData["elementList"] = elementList;
            return View();
        }

        // POST: Pokemen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Total,HP")] Pokemons pokemons, int ElementDropdown)
        {
            if (ModelState.IsValid)
            {
                Pokemons pokemonElement = _context.Pokemons.Find(ElementDropdown);
                _context.Add(pokemons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pokemons);
        }

        // GET: Pokemen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemons = await _context.Pokemons.FindAsync(id);
            if (pokemons == null)
            {
                return NotFound();
            }
            return View(pokemons);
        }

        // POST: Pokemen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ElementType,Total,HP")] Pokemons pokemons)
        {
            if (id != pokemons.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pokemons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PokemonsExists(pokemons.Id))
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
            return View(pokemons);
        }

        // GET: Pokemen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pokemons = await _context.Pokemons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pokemons == null)
            {
                return NotFound();
            }

            return View(pokemons);
        }

        // POST: Pokemen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pokemons = await _context.Pokemons.FindAsync(id);
            _context.Pokemons.Remove(pokemons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PokemonsExists(int id)
        {
            return _context.Pokemons.Any(e => e.Id == id);
        }
    }
}

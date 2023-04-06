using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeSpokeApp.Repository;
using BeSpokeApp.Repository.Models;

namespace BeSpokeApp.Controllers
{
    public class SalespersonsController : Controller
    {
        private readonly BespokeDbContext _context;

        public SalespersonsController(BespokeDbContext context)
        {
            _context = context;
        }

        // GET: Salespersons
        public async Task<IActionResult> Index()
        {
              return _context.SalesPerson != null ? 
                          View(await _context.SalesPerson.ToListAsync()) :
                          Problem("Entity set 'BespokeDbContext.Salespeople'  is null.");
        }

        // GET: Salespersons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SalesPerson == null)
            {
                return NotFound();
            }

            var salesperson = await _context.SalesPerson
                .FirstOrDefaultAsync(m => m.SalesPersonId == id);
            if (salesperson == null)
            {
                return NotFound();
            }

            return View(salesperson);
        }

        // GET: Salespersons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salespersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesPersonId,FirstName,LastName,Address,Phone,StartDate,TerminationDate,Manager")] Salesperson salesperson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesperson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesperson);
        }

        // GET: Salespersons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SalesPerson == null)
            {
                return NotFound();
            }

            var salesperson = await _context.SalesPerson.FindAsync(id);
            if (salesperson == null)
            {
                return NotFound();
            }
            return View(salesperson);
        }

        // POST: Salespersons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesPersonId,FirstName,LastName,Address,Phone,StartDate,TerminationDate,Manager")] Salesperson salesperson)
        {
            if (id != salesperson.SalesPersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesperson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalespersonExists(salesperson.SalesPersonId))
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
            return View(salesperson);
        }

        // GET: Salespersons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SalesPerson == null)
            {
                return NotFound();
            }

            var salesperson = await _context.SalesPerson
                .FirstOrDefaultAsync(m => m.SalesPersonId == id);
            if (salesperson == null)
            {
                return NotFound();
            }

            return View(salesperson);
        }

        // POST: Salespersons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SalesPerson == null)
            {
                return Problem("Entity set 'BespokeDbContext.Salespeople'  is null.");
            }
            var salesperson = await _context.SalesPerson.FindAsync(id);
            if (salesperson != null)
            {
                _context.SalesPerson.Remove(salesperson);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalespersonExists(int id)
        {
          return (_context.SalesPerson?.Any(e => e.SalesPersonId == id)).GetValueOrDefault();
        }
    }
}

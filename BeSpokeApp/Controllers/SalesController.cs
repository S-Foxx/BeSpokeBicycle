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
    public class SalesController : Controller
    {
        private readonly BespokeDbContext _context;

        public SalesController(BespokeDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var bespokeDbContext = _context.Sales.Include(s => s.Customer).Include(s => s.Product).Include(s => s.SalesPerson);
            return View(await bespokeDbContext.ToListAsync());
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId");
            ViewData["SalesPersonId"] = new SelectList(_context.SalesPerson, "SalesPersonId", "SalesPersonId");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,SalesPersonId,CustomerId,SalesDate")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", sale.CustomerId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductId", sale.ProductId);
            ViewData["SalesPersonId"] = new SelectList(_context.SalesPerson, "SalesPersonId", "SalesPersonId", sale.SalesPersonId);
            return View(sale);
        }

        private bool SaleExists(int id)
        {
          return (_context.Sales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

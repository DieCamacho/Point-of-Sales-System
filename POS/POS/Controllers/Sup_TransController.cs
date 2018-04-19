using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Models;

namespace POS.Controllers
{
    public class Sup_TransController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Sup_TransController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sup_Trans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sup_Trans.ToListAsync());
        }

        // GET: Sup_Trans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sup_Trans = await _context.Sup_Trans
                .SingleOrDefaultAsync(m => m.OrderNum == id);
            if (sup_Trans == null)
            {
                return NotFound();
            }

            return View(sup_Trans);
        }

        // GET: Sup_Trans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sup_Trans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierUpdate,Transaction_ID,ProductName")] Sup_Trans sup_Trans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sup_Trans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sup_Trans);
        }

        // GET: Sup_Trans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sup_Trans = await _context.Sup_Trans.SingleOrDefaultAsync(m => m.OrderNum == id);
            if (sup_Trans == null)
            {
                return NotFound();
            }
            return View(sup_Trans);
        }

        // POST: Sup_Trans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierUpdate,Transaction_ID,ProductName")] Sup_Trans sup_Trans)
        {
            if (id != sup_Trans.OrderNum)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sup_Trans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Sup_TransExists(sup_Trans.OrderNum))
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
            return View(sup_Trans);
        }

        // GET: Sup_Trans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sup_Trans = await _context.Sup_Trans
                .SingleOrDefaultAsync(m => m.OrderNum == id);
            if (sup_Trans == null)
            {
                return NotFound();
            }

            return View(sup_Trans);
        }

        // POST: Sup_Trans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sup_Trans = await _context.Sup_Trans.SingleOrDefaultAsync(m => m.OrderNum == id);
            _context.Sup_Trans.Remove(sup_Trans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Sup_TransExists(int id)
        {
            return _context.Sup_Trans.Any(e => e.OrderNum == id);
        }
    }
}

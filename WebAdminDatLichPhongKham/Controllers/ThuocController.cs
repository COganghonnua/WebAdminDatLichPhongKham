﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAdminDatLichPhongKham.Areas.Identity.Data;
using WebAdminDatLichPhongKham.Models;

namespace WebAdminDatLichPhongKham.Controllers
{
    public class ThuocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThuocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Thuoc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Thuocs.ToListAsync());
        }

        // GET: Thuoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thuoc == null)
            {
                return NotFound();
            }

            return View(thuoc);
        }

        // GET: Thuoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Thuoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenThuoc,GiaTien")] Thuoc thuoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thuoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thuoc);
        }

        // GET: Thuoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc == null)
            {
                return NotFound();
            }
            return View(thuoc);
        }

        // POST: Thuoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenThuoc,GiaTien")] Thuoc thuoc)
        {
            if (id != thuoc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thuoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThuocExists(thuoc.Id))
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
            return View(thuoc);
        }

        // GET: Thuoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thuoc = await _context.Thuocs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thuoc == null)
            {
                return NotFound();
            }

            return View(thuoc);
        }

        // POST: Thuoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thuoc = await _context.Thuocs.FindAsync(id);
            if (thuoc != null)
            {
                _context.Thuocs.Remove(thuoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThuocExists(int id)
        {
            return _context.Thuocs.Any(e => e.Id == id);
        }
    }
}

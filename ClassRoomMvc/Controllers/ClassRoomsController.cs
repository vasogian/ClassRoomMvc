﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassRoomMvc.Data;
using ClassRoomMvc.Models;

namespace ClassRoomMvc.Controllers
{
    public class ClassRoomsController : Controller
    {
        private readonly ClassRoomMvcContext _context;

        public ClassRoomsController(ClassRoomMvcContext context)
        {
            _context = context;
        }

        // GET: ClassRooms
        public async Task<IActionResult> Index()
        {
              return _context.ClassRoom != null ? 
                          View(await _context.ClassRoom.ToListAsync()) :
                          Problem("Entity set 'ClassRoomMvcContext.ClassRoom'  is null.");
        }

        // GET: ClassRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClassRoom == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRoom
                .FirstOrDefaultAsync(m => m.ClassRoomId == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // GET: ClassRooms/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: ClassRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassRoomId,Name,Capacity")] ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classRoom);
        }

        // GET: ClassRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClassRoom == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRoom.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }
            return View(classRoom);
        }

        // POST: ClassRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassRoomId,Name,Capacity")] ClassRoom classRoom)
        {
            if (id != classRoom.ClassRoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassRoomExists(classRoom.ClassRoomId))
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
            return View(classRoom);
        }

        // GET: ClassRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClassRoom == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRoom
                .FirstOrDefaultAsync(m => m.ClassRoomId == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // POST: ClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClassRoom == null)
            {
                return Problem("Entity set 'ClassRoomMvcContext.ClassRoom'  is null.");
            }
            var classRoom = await _context.ClassRoom.FindAsync(id);
            if (classRoom != null)
            {
                _context.ClassRoom.Remove(classRoom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassRoomExists(int id)
        {
          return (_context.ClassRoom?.Any(e => e.ClassRoomId == id)).GetValueOrDefault();
        }
    }
}

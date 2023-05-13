﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassRoomMvc.Data;
using ClassRoomMvc.Models;
using ClassRoomMvc.Services;

namespace ClassRoomMvc.Controllers
{
    public class ClassRoomsController : Controller
    {
        private readonly ClassRoomService _service;

        public ClassRoomsController(ClassRoomService service)
        {
            _service = service;
        }

        // GET: ClassRooms
        public async Task<IActionResult> Index()
        {
            var getClassRooms = await _service.GetAllClassRooms();
            if (!getClassRooms.Any())
            {
                return Problem("Entity set 'ClassRoomMvcContext.ClassRoom'  is null.");
            }

            return View(getClassRooms);

        }

        // GET: ClassRooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var selectedClassRoom = await _service.GetClassRoom(id);
            if (selectedClassRoom == null)
            {
                return NotFound();
            }
            return View(selectedClassRoom);
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
        public async Task<IActionResult> Create([Bind("ClassRoomId,TeacherId,StudentId,AssignmentId")] ClassRoom classRoom)
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
        public async Task<IActionResult> Edit(int id, [Bind("ClassRoomId,TeacherId,StudentId,AssignmentId")] ClassRoom classRoom)
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
